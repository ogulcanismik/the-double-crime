using System.Collections;
using TMPro;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
    [SerializeField] private SaveScript saveScript;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject loadingUI;
    [SerializeField] private TextMeshProUGUI saveButtonLabel;
    [SerializeField] private CanvasGroup loadingCanvasGroup;

    public static PauseMenuController Instance;

    void Awake() {
        if (loadingCanvasGroup == null && loadingUI != null) {
            loadingCanvasGroup = loadingUI.GetComponent<CanvasGroup>();
        }
        if (saveButtonLabel == null && pauseMenuUI != null) {
            Transform t = pauseMenuUI.transform.Find("Save/SaveText");
            if (t != null) saveButtonLabel = t.GetComponent<TextMeshProUGUI>();
        }

        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void ShowMenu(bool flag){
        if (flag) {
            pauseMenuUI.SetActive(true);
            //Additional logic 
            if (saveButtonLabel != null) saveButtonLabel.text = "Save";
        }
        else {
            pauseMenuUI.SetActive(false);
        }
    }

    public void Save() {
        saveScript.Save();
        if (saveButtonLabel != null) saveButtonLabel.text = "Saved!";
    }

    public void Load() {
        saveScript.Load();
        StartCoroutine(LoadRoutine());
    }

    public IEnumerator LoadRoutine() {
        loadingCanvasGroup.blocksRaycasts = true;
        yield return FadeAlpha(0f, 1f, 0.5f);
        yield return new WaitForSeconds(SaveScript.LoadApplyDelay);
        GameManagerScript.Instance.PauseGame(false);
        yield return new WaitForSeconds(2f);
        yield return FadeAlpha(1f, 0f, 1f);
        loadingCanvasGroup.blocksRaycasts = false;
    }

    public void SaveAndQuit() {
        saveScript.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Quit() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    IEnumerator FadeAlpha(float start, float end, float duration) {
        float elapsed = 0f;
        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            loadingCanvasGroup.alpha = Mathf.Lerp(start, end, elapsed / duration);
            yield return null;
        }
        loadingCanvasGroup.alpha = end;
    }
}
