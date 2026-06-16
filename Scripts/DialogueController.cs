using System.Collections;
using Esper.ESave;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour, ISaveable {
    [Header("Ink")]
    public TextAsset inkJSONAsset;
    public Story story;
    [Header("UI")]
    public GameObject dialogueUI;
    [SerializeField] private TextMeshProUGUI npcNameText;
    [SerializeField] private Image portraitImage;

    private NPCSO currentNPCData;

    public GameObject dialogueTextPrefab;
    public Transform dialogueTextContent;
    public ScrollRect dialogueTextScroll;

    public GameObject choiceButtonPrefab;
    public Transform choiceButtonPanel;

    void Awake() {
        if (dialogueUI == null) return;
        if (npcNameText == null) {
            Transform t = dialogueUI.transform.Find("DialogueUIText");
            if (t != null) npcNameText = t.GetComponent<TextMeshProUGUI>();
        }
        if (portraitImage == null) {
            Transform t = dialogueUI.transform.Find("DialogueUIPortraitImage");
            if (t != null) portraitImage = t.GetComponent<Image>();
        }
    }

    void Start() {
        if (inkJSONAsset == null) {
            Debug.LogError("DialogueController: inkJSONAsset is not assigned.", this);
            return;
        }
        story = new Story(inkJSONAsset.text);

        story.BindExternalFunction("DiscoverNPC", () => {
            if (currentNPCData != null) {
                currentNPCData.discovered = true;
            }
        });

        story.BindExternalFunction("ModifyOpinion", (int amount) => {
            if (currentNPCData != null) {
                currentNPCData.opinionValue += amount;
            }
        });

    }

    public void StartUI(NPCSO npcData) {
        if (story == null) return;

        currentNPCData = npcData;                                                                                                           

        // 1. Önceki konuşmalardan kalan eski yazıları temizleyelim
        foreach (Transform child in dialogueTextContent) {
            Destroy(child.gameObject);
        }

        // 2. Ink içindeki speaker değişkenini güncelle (Eğer Ink'te VAR speaker varsa)
        story.variablesState["speaker"] = npcData.npcName;

        // 3. UI elemanlarını doldur
        if (npcNameText != null) npcNameText.text = npcData.npcName;
        if (portraitImage != null) portraitImage.sprite = npcData.portrait;
        dialogueUI.gameObject.SetActive(true);

        string knot = npcData.inkKnotName;
        if (story.state.VisitCountAtPathString(knot) != 0) {
            var knotTags = story.TagsForContentAtPath(knot);
        
            if (knotTags != null) {
                foreach (string tag in knotTags) {
                    if (tag.StartsWith("fallback:")) {
                        knot = tag.Replace("fallback:", "").Trim();
                        break; 
                    }
                }
            }
        }

        story.ChoosePathString(knot);
        ContinueStory();
    }

    public void StopUI() {
        RemoveChoices();
        dialogueUI.gameObject.SetActive(false);
        GameManagerScript.Instance.DeselectNPC();
    }

    public void ContinueStory() {
        while (story.canContinue) {
            string text = story.Continue().Trim(); // .Trim() boş satır atlamalarını engeller
            if (!string.IsNullOrEmpty(text)) {
                AddDialogueLine(text);
            }
        }

        // Eğer hikaye bittiyse ve HİÇ seçenek kalmadıysa diyalog penceresini kapatma butonu koyabilirsin
        if (story.currentChoices.Count > 0) {
            CreateChoices();
        } else {
            CreateCloseButton(); // Seçenek kalmadığında oyuncu UI'ı kapatabilsin
        }
    }

    public void AddDialogueLine(string text) {
        GameObject newLine = Instantiate(dialogueTextPrefab, dialogueTextContent);
        newLine.GetComponentInChildren<TextMeshProUGUI>().text = text;
        StartCoroutine(ScrollToBottom());
    }

    IEnumerator ScrollToBottom() {
        yield return new WaitForEndOfFrame();
        if (dialogueTextScroll != null) {
            dialogueTextScroll.verticalNormalizedPosition = 0f;
        }
        if (dialogueTextContent.childCount > 50) {
            Destroy(dialogueTextContent.GetChild(0).gameObject);
        }
    }

    void CreateChoices() {
        RemoveChoices();

        foreach (Choice choice in story.currentChoices) {
            GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceButtonPanel);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = choice.text;

            Button btn = buttonObj.GetComponent<Button>();
            // lambda closure hatasını engellemek için yerel değişken oluşturuyoruz
            int choiceIndex = choice.index; 
            btn.onClick.AddListener(() => {
                RemoveChoices();
                MakeChoice(choiceIndex);
            });
        }
    }

    // Diyalog bittiğinde UI'ı kapatacak geçici bir buton
    void CreateCloseButton() {
        RemoveChoices();
        GameObject buttonObj = Instantiate(choiceButtonPrefab, choiceButtonPanel);
        buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "[Konuşmayı Bitir]";
        Button btn = buttonObj.GetComponent<Button>();
        btn.onClick.AddListener(() => StopUI());
    }

    void RemoveChoices() {
        foreach (Transform child in choiceButtonPanel) {
            Destroy(child.gameObject);
        }
    }

    public void MakeChoice(int choiceIndex) {
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }


    public void OnSave(SaveFile saveFile) {
        if (story == null) return;
        saveFile.AddOrUpdateData("storyState", story.state.ToJson());
    }

    public void OnLoad(SaveFile saveFile) {
        if (story == null) return;
        string json = saveFile.GetData<string>("storyState", null);
        if (json != null) story.state.LoadJson(json);
    }
}