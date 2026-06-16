using System.Collections;
using UnityEngine;

public class BasementTeleporterScript : MonoBehaviour {
    [SerializeField] GameObject dest;
    [SerializeField] GameObject player;
    [SerializeField] PlayerCameraController.regions region;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
    }

    void Update() {

    }

    public void Teleport() {
        StartCoroutine(PauseMenuController.Instance.LoadRoutine());
        StartCoroutine(TeleportRoutine());
    }

    IEnumerator TeleportRoutine() {
        yield return new WaitForSeconds(0.5f);
        player.transform.position = dest.transform.position;
        player.GetComponent<PlayerCameraController>().HandleRegionChange(region);
    }
        

}
