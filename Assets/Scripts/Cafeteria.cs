using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafeteria : MonoBehaviour
{
    public GameObject OtraEscena;
    public GameObject EscenaActual;
    public GameObject panelTransición;

    void Start()
    {

    }

    void Update()
    {

    }

    // Método público para cambiar entre las escenas
    public void CambiarEscena()
    {
        StartCoroutine(ActivarCafeteriaDespuesDeRetraso());
    }

    // Corutina para activar CafeteriaEscena después de un retraso
    IEnumerator ActivarCafeteriaDespuesDeRetraso()
    {
        panelTransición.SetActive(true);
        yield return new WaitForSeconds(1f); // Esperar otro segundo
        panelTransición.SetActive(false);
        EscenaActual.SetActive(false); // Desactivar la escena de entrada
        Debug.Log("otra escena");
        OtraEscena.SetActive(true); // Activar la otra escena

    }
}
