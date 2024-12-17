using System.Collections;
using UnityEngine;
using TMPro;

public class TypeOutLetters : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float letterDelay = 0.05f;
    private string fullText;

    public GameObject objectToEnable;

    private void Awake()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TextMeshProUGUI>();

        fullText = textMeshPro.text;
        textMeshPro.text = "";
    }

    private void Start()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        StopAllCoroutines();
        StartCoroutine(TypeLetters());
    }

    private IEnumerator TypeLetters()
    {
        textMeshPro.text = "";

        for (int i = 0; i < fullText.Length; i++)
        {
            textMeshPro.text += fullText[i];
            yield return new WaitForSeconds(letterDelay);
        }

        if (objectToEnable != null)
        {
            objectToEnable.SetActive(true);
        }
    }
}
