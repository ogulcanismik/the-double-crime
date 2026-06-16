using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private CanvasGroup loadingCanvasGroup;
    [SerializeField] private VideoClip mainMenuVideo1;
    [SerializeField] private VideoClip mainMenuVideo2;

    public void StartGame() {
        videoPlayer.GetComponent<VideoPlayer>().clip = mainMenuVideo2;
        StartCoroutine(WaitBeforeStart());
    }

    public void QuitGame() {
        Application.Quit();
    }

    IEnumerator WaitBeforeStart() {
        Debug.Log("Playing main menu video...");
        StartCoroutine(FadeAlpha(0f, 1f, 1.5f));
        yield return new WaitForSeconds(2);
        Debug.Log("Starting game...");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
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
