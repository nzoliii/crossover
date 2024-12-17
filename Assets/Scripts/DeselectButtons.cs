using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeselectAllButtons : MonoBehaviour
{
    public Button[] buttons; // Gomb lista

    void Start()
    {
        // Listener
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        // Megcsinálja hogy a gomb ne legyen kiválasztva
        EventSystem.current.SetSelectedGameObject(null);
    }
}
