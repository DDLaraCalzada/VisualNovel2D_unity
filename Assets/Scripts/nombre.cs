using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class nombre : MonoBehaviour
{

    public TMP_InputField inputField;
    public TextMeshProUGUI[] textMeshPros;
    public Button button; // Botón asignado públicamente desde el Inspector


    public void CopiarTextoEnText()
    {
        string texto = inputField.text;

        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            textMeshPro.text = texto;
        }

        Debug.Log("Se llamó al método CopiarTextoEnText() al presionar el botón.");

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
