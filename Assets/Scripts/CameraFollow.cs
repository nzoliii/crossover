using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;            // Player gameobject
    public float smoothSpeed = 0.125f;  // Sebesség amivel a kamera követi a player gameobjectet
    public Vector3 offset;              // offset

    void LateUpdate()
    {
        // Kamerapozíciószámítás
        Vector3 desiredPosition = player.position + offset;

        // Kamera lassú mozgatása
        Vector3 smoothedPosition = new Vector3(
            Mathf.Lerp(transform.position.x, desiredPosition.x, smoothSpeed),
            Mathf.Lerp(transform.position.y, desiredPosition.y, smoothSpeed),
            transform.position.z // Z tengely ne változzon
        );

        // Kamera pozíció frissítése
        transform.position = smoothedPosition;
    }
}
