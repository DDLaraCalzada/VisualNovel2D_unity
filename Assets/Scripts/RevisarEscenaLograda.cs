using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisarEscenaLograda : MonoBehaviour
{
    public GameObject EscenaCafeter�a;
    public GameObject EscenaBiblioteca;
    public GameObject EscenaDormitorio;

    public GameObject btnCafeter�a;
    public GameObject btnBiblioteca;
    public GameObject btnDormitorio;

    private bool cafeter�aActivada;
    private bool bibliotecaActivada;
    private bool dormitorioActivado;

    void Start()
    {
        // Inicialmente, ninguna escena est� activada
        cafeter�aActivada = false;
        bibliotecaActivada = false;
        dormitorioActivado = false;
    }

    void Update()
    {
        // Verificar si alguna de las escenas se ha activado al menos una vez
        if (EscenaCafeter�a.activeSelf && !cafeter�aActivada)
        {
            cafeter�aActivada = true;
            Invoke("DesactivarBot�nCafeter�a", 2f);
        }

        if (EscenaBiblioteca.activeSelf && !bibliotecaActivada)
        {
            bibliotecaActivada = true;
            Invoke("DesactivarBot�nBiblioteca", 2f);
        }

        if (EscenaDormitorio.activeSelf && !dormitorioActivado)
        {
            dormitorioActivado = true;
            Invoke("DesactivarBot�nDormitorio", 2f);
        }
    }

    // M�todo para desactivar el bot�n de la cafeter�a despu�s de 1 segundo
    void DesactivarBot�nCafeter�a()
    {
        if (btnCafeter�a != null)
        {
            btnCafeter�a.SetActive(false);
        }
    }

    // M�todo para desactivar el bot�n de la biblioteca despu�s de 1 segundo
    void DesactivarBot�nBiblioteca()
    {
        if (btnBiblioteca != null)
        {
            btnBiblioteca.SetActive(false);
        }
    }

    // M�todo para desactivar el bot�n del dormitorio despu�s de 1 segundo
    void DesactivarBot�nDormitorio()
    {
        if (btnDormitorio != null)
        {
            btnDormitorio.SetActive(false);
        }
    }
}

