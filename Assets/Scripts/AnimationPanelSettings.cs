using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPanelSettings : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Animator animator;          // Asigna el Animator del panel
    //[SerializeField] private GameObject panelRoot;       // (Opcional) El GameObject del panel

    [Header("Triggers del Animator")]
    [SerializeField] private string triggerEntrada = "entrada";
    [SerializeField] private string triggerSalida = "salida";

    
    //[SerializeField] private bool activarPanelAlEntrar = true;  // Activa el GO al hacer entrada
    //[SerializeField] private bool desactivarAlSalirAlFinal = false; // Desactiva el GO al terminar salida (usa evento de animación)

    // Llama la animación de entrada
    public void Mostrar()
    {
        //if (panelRoot && activarPanelAlEntrar) panelRoot.SetActive(true);
        if (animator) animator.SetTrigger(triggerEntrada);
    }

    // Llama la animación de salida
    public void Ocultar()
    {
        if (animator) animator.SetTrigger(triggerSalida);
    }

    // Atajo para alternar
    public void Toggle(bool visible)
    {
        if (visible) Mostrar();
        else Ocultar();
    }

    // Para ser llamado desde un Evento de Animación al final del clip "salida"
    //public void OnSalidaTerminada()
    //{
    //    if (panelRoot && desactivarAlSalirAlFinal) panelRoot.SetActive(false);
    //}
}
