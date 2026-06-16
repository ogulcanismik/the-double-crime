using UnityEngine;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LedgerController : MonoBehaviour
{
    public static LedgerController Instance;
    private NPCController[] npcList;
    private bool isLedgerOpen = false;

    [SerializeField] private GameObject npcEntryPrefab;
    [SerializeField] private GameObject ledgerUI;
    [SerializeField] private GameObject ledgerCanvas;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }


    void Start()
    {
        npcList = GameManagerScript.Instance.npcControllerList;
        InitilizeLedger();
    }

    void InitilizeLedger() {
        float x = 1000f;
        float y = 750f;
        foreach (NPCController npc in npcList) {
            GameObject entry = Instantiate(npcEntryPrefab, ledgerCanvas.transform);
            
            FillEntry(entry, npc);

            entry.transform.localPosition = new Vector3(x, y, 0);
            y -= 200f;
            if(y<350){
                y = 750f;
                x += 750f;
            }
        }
    }

    void FillEntry(GameObject entry, NPCController npc) {
        Transform portraitT = entry.transform.Find("Portrait");
        portraitT.GetComponent<Image>().sprite = npc.npcData.portrait;

        Transform nameT = entry.transform;
        nameT.GetComponent<TextMeshProUGUI>().text = npc.npcData.discovered ? npc.npcData.npcName : "???";

        Transform opinionT = entry.transform.Find("Opinion");
        string opinionText = "Neutral";
        if(npc.npcData.opinionValue > 0) opinionText = "Positive";
        else if(npc.npcData.opinionValue < 0) opinionText = "Negative";
        else if(npc.npcData.opinionValue > 50) opinionText = "Highly Positive";
        else if(npc.npcData.opinionValue < -50) opinionText = "Highly Negative";

        opinionT.GetComponent<TextMeshProUGUI>().text = npc.npcData.discovered ? opinionText : "???";
    }

    void UpdateEntries() {
        foreach (Transform child in ledgerCanvas.transform) {
            Destroy(child.gameObject);
        }
        InitilizeLedger();
    }

    public void ShowLedger() {
        isLedgerOpen = !isLedgerOpen;
        ledgerUI.SetActive(isLedgerOpen);
        UpdateEntries();
    }

}
