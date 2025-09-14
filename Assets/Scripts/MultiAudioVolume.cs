using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiAudioVolume : MonoBehaviour
{



    [Header("UI")]
    [SerializeField] private Slider volumeSlider;   // Asigna tu Slider (min 0, max 1)

    [Header("Objetos con Audio")]
    [Tooltip("Arrastra aquí objetos que tengan AudioSource (en ellos o en hijos).")]
    public List<GameObject> objetosConAudio = new List<GameObject>();

    [Tooltip("Si está activo, también buscará AudioSource en los hijos de cada objeto.")]
    [SerializeField] private bool incluirHijos = true;

    // Cache de todas las fuentes encontradas
    private readonly List<AudioSource> _fuentes = new List<AudioSource>();

    private void Start()
    {
        // Asegura que el volumen inicial refleje el valor actual del slider
        if (volumeSlider != null)
            ActualizarVolumen(volumeSlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Awake()
    {
        RecolectarFuentes();
    }

    private void OnEnable()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(ActualizarVolumen);
        }
    }



    private void OnDisable()
    {
        if (volumeSlider != null)
            volumeSlider.onValueChanged.RemoveListener(ActualizarVolumen);
    }

    /// <summary>
    /// Vuelve a buscar AudioSource en la lista pública (útil si agregas objetos en runtime).
    /// </summary>
    public void RecolectarFuentes()
    {
        _fuentes.Clear();

        foreach (var go in objetosConAudio)
        {
            if (go == null) continue;

            if (incluirHijos)
                _fuentes.AddRange(go.GetComponentsInChildren<AudioSource>(true));
            else
            {
                var src = go.GetComponent<AudioSource>();
                if (src != null) _fuentes.Add(src);
            }
        }
    }

    /// <summary>
    /// Llama el slider (0–1). Aplica a todas las fuentes.
    /// </summary>
    public void ActualizarVolumen(float valor01)
    {
        valor01 = Mathf.Clamp01(valor01);
        foreach (var src in _fuentes)
        {
            if (src != null) src.volume = valor01;
        }
    }

    /// <summary>
    /// Agrega un objeto en caliente (opcional).
    /// </summary>
    public void AgregarObjeto(GameObject go)
    {
        if (go == null) return;
        objetosConAudio.Add(go);
        // Solo incorpora sus AudioSource sin reconstruir todo
        if (incluirHijos)
            _fuentes.AddRange(go.GetComponentsInChildren<AudioSource>(true));
        else
        {
            var src = go.GetComponent<AudioSource>();
            if (src != null) _fuentes.Add(src);
        }
        // Sincroniza con el valor actual del slider
        if (volumeSlider != null) ActualizarVolumen(volumeSlider.value);
    }
}
