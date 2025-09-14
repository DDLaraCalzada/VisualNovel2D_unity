using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class velocidadTexto : MonoBehaviour
{
    public List<TextMeshProUGUI> textMeshPros;
    public List<Image> images;
    public List<string> textList;
    public List<Sprite> imageList;
    public float letterAppearSpeed = 0.01f;
    public Button nextButton;
    public Button otroBoton;
    public GameObject inputText;
    public GameObject panleDialogo;
    public Animator animador1;
    public Animator animador2;

    private List<string> fullTexts = new List<string>();
    private List<string> currentTexts = new List<string>();
    private List<float> timers = new List<float>();
    private int currentIndex = 0;

    private void Start()
    {
        InitializeTexts();
        InitializeButtons();
        InitializeAnimators();
    }

    private void InitializeTexts()
    {
        if (textMeshPros.Count == 0)
        {
            Debug.LogError("No TextMeshProUGUI components assigned to velocidadTexto script!");
            enabled = false;
            return;
        }

        foreach (TextMeshProUGUI textMeshPro in textMeshPros)
        {
            fullTexts.Add(textMeshPro.text);
            currentTexts.Add("");
            timers.Add(0f);
            textMeshPro.text = "";
        }

        if (textList.Count == 0)
        {
            Debug.LogError("No text entries provided in textList!");
            enabled = false;
            return;
        }
    }

    private void InitializeButtons()
    {
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(ShowNextText);
        }

        if (otroBoton != null)
        {
            otroBoton.gameObject.SetActive(false);
        }
    }

    private void InitializeAnimators()
    {
        if (animador1 != null)
        {
            animador1.enabled = false;
        }

        if (animador2 != null)
        {
            animador2.enabled = false;
        }
    }

    private void Update()
    {
        UpdateTextAppearance();
    }

    private void UpdateTextAppearance()
    {
        for (int i = 0; i < textMeshPros.Count; i++)
        {
            timers[i] += Time.deltaTime;
            if (timers[i] >= letterAppearSpeed)
            {
                timers[i] -= letterAppearSpeed;
                if (currentTexts[i].Length < fullTexts[i].Length)
                {
                    currentTexts[i] += fullTexts[i][currentTexts[i].Length];
                    textMeshPros[i].text = currentTexts[i];
                }
            }
        }
    }

    public void ActivarAnimacionSalidaInput()
    {
        if (animador2 != null)
        {
            animador2.SetBool("Salida Input", true);
            animador2.SetBool("Entrada Input", false);

        }
    }

    private void ShowNextText()
    {
        currentIndex++;
        if (currentIndex >= textList.Count)
        {
            currentIndex = 0;
            HandleButtonActivation();
        }

        UpdateTextsAndImages();
    }

    private void HandleButtonActivation()
    {
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);
        }

        if (otroBoton != null)
        {
            otroBoton.gameObject.SetActive(true);
            if (animador1 != null)
            {
                animador1.enabled = true;
                animador1.SetBool("salida", true);
            }

            if (animador2 != null)
            {
                animador2.enabled = true;
                animador2.SetBool("Entrada Input", true);
            }
        }
    }

    private void UpdateTextsAndImages()
    {
        for (int i = 0; i < textMeshPros.Count; i++)
        {
            fullTexts[i] = textList[currentIndex];
            currentTexts[i] = "";
            textMeshPros[i].text = "";
        }

        UpdateImages();
    }

    private void UpdateImages()
    {
        if (currentIndex < imageList.Count)
        {
            foreach (Image image in images)
            {
                image.sprite = imageList[currentIndex];
            }
        }
        else
        {
            Debug.LogWarning("Index out of range for imageList!");
        }
    }
}
