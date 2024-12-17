using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameObject objectToEnable; // Gameobject amit be kell kapcsolni

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collision ellenőrzés
        if (other.CompareTag("Player"))
        {
            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true); // Gameobject bekapcsolása
                Debug.Log("GameObject Enabled.");
            }
        }
    }
}
