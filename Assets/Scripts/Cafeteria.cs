using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafeteria : MonoBehaviour
{
    public GameObject OtraEscena;
    public GameObject EscenaActual;
    public GameObject panelTransici�n;

    void Start()
    {

    }

    void Update()
    {

    }

    // M�todo p�blico para cambiar entre las escenas
    public void CambiarEscena()
    {
        StartCoroutine(ActivarCafeteriaDespuesDeRetraso());
    }

    // Corutina para activar CafeteriaEscena despu�s de un retraso
    IEnumerator ActivarCafeteriaDespuesDeRetraso()
    {
        panelTransici�n.SetActive(true);
        yield return new WaitForSeconds(1f); // Esperar otro segundo
        panelTransici�n.SetActive(false);
        EscenaActual.SetActive(false); // Desactivar la escena de entrada
        Debug.Log("otra escena");
        OtraEscena.SetActive(true); // Activar la otra escena

    }
}
