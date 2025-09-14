using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevisarEscenaLograda : MonoBehaviour
{
    public GameObject EscenaCafetería;
    public GameObject EscenaBiblioteca;
    public GameObject EscenaDormitorio;

    public GameObject btnCafetería;
    public GameObject btnBiblioteca;
    public GameObject btnDormitorio;

    private bool cafeteríaActivada;
    private bool bibliotecaActivada;
    private bool dormitorioActivado;

    void Start()
    {
        // Inicialmente, ninguna escena está activada
        cafeteríaActivada = false;
        bibliotecaActivada = false;
        dormitorioActivado = false;
    }

    void Update()
    {
        // Verificar si alguna de las escenas se ha activado al menos una vez
        if (EscenaCafetería.activeSelf && !cafeteríaActivada)
        {
            cafeteríaActivada = true;
            Invoke("DesactivarBotónCafetería", 2f);
        }

        if (EscenaBiblioteca.activeSelf && !bibliotecaActivada)
        {
            bibliotecaActivada = true;
            Invoke("DesactivarBotónBiblioteca", 2f);
        }

        if (EscenaDormitorio.activeSelf && !dormitorioActivado)
        {
            dormitorioActivado = true;
            Invoke("DesactivarBotónDormitorio", 2f);
        }
    }

    // Método para desactivar el botón de la cafetería después de 1 segundo
    void DesactivarBotónCafetería()
    {
        if (btnCafetería != null)
        {
            btnCafetería.SetActive(false);
        }
    }

    // Método para desactivar el botón de la biblioteca después de 1 segundo
    void DesactivarBotónBiblioteca()
    {
        if (btnBiblioteca != null)
        {
            btnBiblioteca.SetActive(false);
        }
    }

    // Método para desactivar el botón del dormitorio después de 1 segundo
    void DesactivarBotónDormitorio()
    {
        if (btnDormitorio != null)
        {
            btnDormitorio.SetActive(false);
        }
    }
}

