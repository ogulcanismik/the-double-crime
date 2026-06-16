using System;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public static event Action<bool> OnPauseChanged;

    public bool isInteracting = false;
    public bool isPaused = false;
    public NPCController currentNPC;

    [SerializeField] private DialogueController dialogueController;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pauseMenuUI;
    // Assigned in the scene for editor reference / future systems; not read in code yet.
    [SerializeField] public NPCController[] npcControllerList;

    public static GameManagerScript Instance;

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isInteracting) {
                DeselectNPC();
            }
            else {
                if (isPaused) {
                    PauseGame(false);
                }
                else {
                    PauseGame(true, true);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Tab)) {
            LedgerController.Instance.ShowLedger();
            isPaused = !isPaused;
            PauseGame(isPaused);
        }
    }

    public void SelectNPC(NPCController npc) {
        currentNPC = npc;
        currentNPC.ApplyDialogueSortingOrder();

        dialogueController.StartUI(npc.npcData);

        isInteracting = true;
        PauseGame(true);
    }

    public void DeselectNPC() {
        if (currentNPC == null) return;

        currentNPC.ResetSortingOrder();
        currentNPC = null;

        isInteracting = false;
        PauseGame(false);

        dialogueController.StopUI();
    }

    public void PauseGame(bool flag, bool withMenu = false) {
        if (flag) {
            pauseUI.SetActive(true);
            if (withMenu) PauseMenuController.Instance.ShowMenu(true);
            isPaused = true;
        }
        else {
            pauseUI.SetActive(false);
            PauseMenuController.Instance.ShowMenu(false);
            isPaused = false;
        }
        OnPauseChanged?.Invoke(isPaused);
    }
}
