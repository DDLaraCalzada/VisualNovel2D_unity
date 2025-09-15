using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto2SpeedController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Slider speedSlider;   // Min=0, Max=1

    [Header("Rango de velocidad (tiempo entre letras)")]
    [Tooltip("0.1f = más lento, 0.01f = más rápido")]
    [SerializeField] private float slowDelay = 0.1f;   // mínimo (lento)
    [SerializeField] private float fastDelay = 0.01f;  // máximo (rápido)

    [Header("Objetivos")]
    [Tooltip("Arrastra aquí los componentes 'texto2' a controlar.")]
    public List<texto2> objetivosTexto2 = new List<texto2>();

    [Tooltip("Arrastra aquí los componentes 'velocidadTexto' a controlar.")]
    public List<velocidadTexto> objetivosVelocidadTexto = new List<velocidadTexto>();

    [Header("Descubrimiento automático")]
    [SerializeField] private bool autoDescubrirTexto2 = false;
    [SerializeField] private bool autoDescubrirVelocidadTexto = false;

    private void Awake()
    {
        if (autoDescubrirTexto2)
        {
            objetivosTexto2.Clear();
            objetivosTexto2.AddRange(FindObjectsOfType<texto2>(true));
        }
        if (autoDescubrirVelocidadTexto)
        {
            objetivosVelocidadTexto.Clear();
            objetivosVelocidadTexto.AddRange(FindObjectsOfType<velocidadTexto>(true));
        }
    }

    private void OnEnable()
    {
        if (speedSlider != null)
            speedSlider.onValueChanged.AddListener(ApplyFromSlider);
    }

    private void Start()
    {
        if (speedSlider != null)
            ApplyFromSlider(speedSlider.value);
    }

    private void OnDisable()
    {
        if (speedSlider != null)
            speedSlider.onValueChanged.RemoveListener(ApplyFromSlider);
    }

    /// <summary>
    /// Mapea el slider [0..1] a [0.1..0.01] y lo aplica a todos los objetivos.
    /// 0 = lento (0.1f), 1 = rápido (0.01f)
    /// </summary>
    public void ApplyFromSlider(float t01)
    {
        t01 = Mathf.Clamp01(t01);
        float delay = Mathf.Lerp(slowDelay, fastDelay, t01);

        for (int i = 0; i < objetivosTexto2.Count; i++)
        {
            var t = objetivosTexto2[i];
            if (t != null) t.letterAppearSpeed = delay;
        }

        for (int i = 0; i < objetivosVelocidadTexto.Count; i++)
        {
            var v = objetivosVelocidadTexto[i];
            if (v != null) v.letterAppearSpeed = delay;
        }
    }

    /// <summary>
    /// Agrega un nuevo 'texto2' en tiempo de ejecución y sincroniza su velocidad.
    /// </summary>
    public void Agregar(texto2 nuevo)
    {
        if (nuevo == null) return;
        objetivosTexto2.Add(nuevo);
        if (speedSlider != null) ApplyFromSlider(speedSlider.value);
    }

    /// <summary>
    /// Agrega un nuevo 'velocidadTexto' en tiempo de ejecución y sincroniza su velocidad.
    /// </summary>
    public void Agregar(velocidadTexto nuevo)
    {
        if (nuevo == null) return;
        objetivosVelocidadTexto.Add(nuevo);
        if (speedSlider != null) ApplyFromSlider(speedSlider.value);
    }
}
