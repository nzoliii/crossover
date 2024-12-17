using UnityEngine;

public class KeyOpensDoor : MonoBehaviour
{
    public GameObject objectToDisable; // Gameobject amit be kell kapcsolni

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collision ellenőrzés
        if (other.CompareTag("Player"))
        {
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false); // Gameobject bekapcsolása
                Debug.Log("GameObject Disabled.");
            }
        }
    }
}
