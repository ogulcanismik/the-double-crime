using UnityEngine;
using Unity.Cinemachine;

public class PlayerCameraController : MonoBehaviour {
    public CinemachineCamera vcam;
    private CinemachinePositionComposer composer;
    public float cameraLeftLimit;
    public float cameraRightLimit;
    public bool lastMovementDirectionRight = false;
    private bool isPaused = false;

    public enum regions {
        Basement,
        MainFloor,
        Deck
    }

    void OnEnable() {
        GameManagerScript.OnPauseChanged += OnPauseChanged;
    }

    void OnDisable() {
        GameManagerScript.OnPauseChanged -= OnPauseChanged;
    }

    void OnPauseChanged(bool paused) {
        isPaused = paused;
    }

    void Start() {
        HandleRegionChange(regions.Deck);
        composer = vcam.GetComponent<CinemachinePositionComposer>();
    }

    void LateUpdate() {
        if (isPaused) {
            HandleCameraFocus();
        }
        else HandleCameraMovement();
    }

    void HandleCameraMovement() {
        lastMovementDirectionRight =
        gameObject.transform.rotation.eulerAngles.y < 185f && gameObject.transform.rotation.eulerAngles.y > 175f ? true : false;

        if (lastMovementDirectionRight) {
            if (vcam.transform.position.x < cameraRightLimit) {
                vcam.Follow = null;
            }
            else {
                composer.Composition.ScreenPosition.x = Mathf.Lerp(composer.Composition.ScreenPosition.x, -0.35f, Time.deltaTime * 3f);
                vcam.Follow = gameObject.transform;
            }
        }
        else {
            if (vcam.transform.position.x > cameraLeftLimit) {
                vcam.Follow = null;
            }
            else {
                composer.Composition.ScreenPosition.x = Mathf.Lerp(composer.Composition.ScreenPosition.x, 0.35f, Time.deltaTime * 3f);
                vcam.Follow = gameObject.transform;
            }
        }
    }

    void HandleCameraFocus() {
        composer.Composition.ScreenPosition.x = Mathf.Lerp(composer.Composition.ScreenPosition.x, -0.15f, Time.deltaTime * 3f);
    }

    public void HandleRegionChange(regions newRegion) {
        if(vcam.Follow == null) {
            vcam.Follow = gameObject.transform;
        } 
        switch (newRegion) {
            case regions.Basement:
                cameraLeftLimit = 20.40f;
                cameraRightLimit = 20.40f;
                break;
            case regions.MainFloor:
                cameraLeftLimit = 8.55f;
                cameraRightLimit = -10.50f;
                break;
            case regions.Deck:
                cameraLeftLimit = -21.00f;
                cameraRightLimit = -26.50f;
                break;
        }
    }
    


}
