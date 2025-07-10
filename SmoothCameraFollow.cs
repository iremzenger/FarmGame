using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [Header("Ayarlar")]
    public Transform target; // Player'�n transformu
    public Vector3 offset = new Vector3(0, 5, -7); // Kamera konumu (X,Y,Z)
    public float smoothSpeed = 5f; // Yumu�akl�k derecesi (5-10 aras� ideal)

    void LateUpdate()
    {
        if (target == null) return;

        // Hedef pozisyonu hesapla (player pozisyonu + offset)
        Vector3 desiredPosition = target.position + offset;

        // Yumu�ak ge�i� i�in Lerp
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.position = smoothedPosition;

        // Player'a bak�� (opsiyonel)
        transform.LookAt(target);
    }
}
