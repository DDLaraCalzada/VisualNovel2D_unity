using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicion : MonoBehaviour
{
    public Animator animadorTransicion;
    public GameObject panelTransicion;


    // Inicialización
    void Start()
    {
        InitializeAnimators();
        panelTransicion.SetActive(true);
        animadorTransicion.SetBool("Oscurecer", true);
    }

    // Método para inicializar el Animator
    private void InitializeAnimators()
    {
        if (animadorTransicion != null)
        {
            animadorTransicion.enabled = false;
        }
    }

   

    // Método para activar la transición de oscurecer
    public void Oscurecer()
    {
        panelTransicion.SetActive(true);

        if (animadorTransicion != null)
        {
            animadorTransicion.SetBool("Oscurecer", true);
            animadorTransicion.SetBool("Final", false);
        }
    }
}
