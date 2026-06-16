using Esper.ESave;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISaveable {
    [SerializeField] private float speed = 5f;
    [SerializeField] private Canvas notificationCanvas;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator shadowAnimator;
    [SerializeField] private LayerMask interactableLayer;

    private bool isPaused = false;
    private Vector3 lastMoveDirection = Vector3.right;

    void OnEnable() {
        GameManagerScript.OnPauseChanged += OnPauseChanged;
    }

    void OnDisable() {
        GameManagerScript.OnPauseChanged -= OnPauseChanged;
    }

    void OnPauseChanged(bool paused) {
        isPaused = paused;
    }

    void Update() {
        HandleMovement();
        HandleInteract();
    }

    void HandleMovement() {
        if (isPaused) return;

        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) {
            moveDirection = Vector3.right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            lastMoveDirection = moveDirection;
        }
        else if (Input.GetKey(KeyCode.D)) {
            moveDirection = Vector3.left;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            lastMoveDirection = moveDirection;
        }

        animator.SetBool("isWalking", moveDirection == Vector3.zero ? false : true);
        shadowAnimator.SetBool("isWalking", moveDirection == Vector3.zero ? false : true);

        transform.position += moveDirection * speed * Time.deltaTime;
        notificationCanvas.transform.position = transform.position;
    }

    void HandleInteract() {
        float interactDistance = 0.5f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastMoveDirection, interactDistance, interactableLayer);
        if (hit.collider != null && !isPaused) {
            if (hit.collider.GetComponent<NPCController>() != null) {
                notificationCanvas.transform.GetChild(0).gameObject.SetActive(true);
            } else if (hit.collider.GetComponent<BasementTeleporterScript>() != null) {
                notificationCanvas.transform.GetChild(1).gameObject.SetActive(true);
            }
            notificationCanvas.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 0.25f, hit.transform.position.z);
            if (Input.GetKeyDown(KeyCode.E)) {
                HandleInteractAction(hit);
            }
        }
        else {
            notificationCanvas.transform.GetChild(0).gameObject.SetActive(false);
            notificationCanvas.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    void HandleInteractAction(RaycastHit2D hit) {
        NPCController npc = hit.collider.GetComponent<NPCController>();
        if (npc != null) {
            GameManagerScript.Instance.SelectNPC(npc);
        }
        else {
            BasementTeleporterScript teleporter = hit.collider.GetComponent<BasementTeleporterScript>();
            if (teleporter != null) {
                teleporter.Teleport();
            }
        }
    }

    public void OnSave(SaveFile saveFile) {
        saveFile.AddOrUpdateData("playerPosition", transform.position);
        saveFile.AddOrUpdateData("playerRotation", transform.rotation.eulerAngles);
    }

    public void OnLoad(SaveFile saveFile) {
        transform.position = saveFile.GetVector3("playerPosition", Vector3.zero);
        transform.rotation = Quaternion.Euler(saveFile.GetVector3("playerRotation", Vector3.zero));
    }
}
