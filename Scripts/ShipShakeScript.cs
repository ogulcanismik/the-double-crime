using UnityEngine;

public class ShipShakeScript : MonoBehaviour {
    [SerializeField] private float shakeIntensity;
    [SerializeField] private float shakeSpeed;

    void Update() {
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * shakeSpeed) * shakeIntensity);
    }
}
