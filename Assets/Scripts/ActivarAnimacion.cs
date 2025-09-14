using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarAnimacion : MonoBehaviour
{
    public Animator animadorSegundoDialogo;
    public Button btnGuardar;
    // Start is called before the first frame update
    void Start()
    {
        InitializeAnimators();
    }


    private void InitializeAnimators()
    {
        if (animadorSegundoDialogo != null)
        {
            animadorSegundoDialogo.enabled = false;
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }

    public void ActivarEntrada()
    {
        if (animadorSegundoDialogo != null)
        {
            if (animadorSegundoDialogo != null)
            {
                animadorSegundoDialogo.SetBool("Salida Input", true);
                animadorSegundoDialogo.enabled = true;
            }

        }
    }
}
