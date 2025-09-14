using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class texto2 : MonoBehaviour
{
    public List<TextMeshProUGUI> textMeshPros;
    public List<Image> images;
    public List<string> textList;
    public List<Sprite> imageList;
    public float letterAppearSpeed = 0.01f;
    public Button nextButton;
    public GameObject nombrePlayer;
    public GameObject NombreNPC;
    public GameObject Opciones;
    public GameObject CampoDeTexto;
    public Animator animadorOpciones;
    public Animator animadorDialogo2;
    public Animator animadorFinal;
    public GameObject Final;

    private List<string> fullTexts = new List<string>();
    private List<string> currentTexts = new List<string>();
    private List<float> timers = new List<float>();
    private int currentIndex = 0;

    private void Start()
    {
        InitializeTexts();
        InitializeButtons();
        SetInitialNameActive();

        if (Opciones != null)
        {
            Opciones.SetActive(false);
        }
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
    }

    private void SetInitialNameActive()
    {
        if (nombrePlayer != null)
        {
            nombrePlayer.SetActive(false);
        }

        if (NombreNPC != null)
        {
            NombreNPC.SetActive(true);
        }


    }

    private void InitializeAnimators()
    {
        if (animadorOpciones != null)
        {
            animadorOpciones.enabled = false;
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

    private void ShowNextText()
    {
        currentIndex++;
        if (currentIndex >= textList.Count)
        {
            currentIndex = 0;
            UpdateTextsAndImages();
            ToggleNameObjects();
            CheckEndOfTexts();
        }
        else
        {
            UpdateTextsAndImages();
            ToggleNameObjects();
        }
    }

    private void ToggleNameObjects()
    {
        if (nombrePlayer != null && NombreNPC != null)
        {
            nombrePlayer.SetActive(!nombrePlayer.activeSelf);
            NombreNPC.SetActive(!NombreNPC.activeSelf);
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

    private void CheckEndOfTexts()
    {
        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(false);
        }

        if (Opciones != null)
        {
            Opciones.SetActive(true);
        }

        if (animadorOpciones != null)
        {
            animadorOpciones.SetBool("Opciones Entrada", true);
        }

        if (animadorDialogo2 != null)
        {
            animadorDialogo2.SetBool("Salida Dialogo 2", true);
        }

        if (animadorFinal != null)
        {
            Final.SetActive(true);
        }

        if (CampoDeTexto != null)
        {
            CampoDeTexto.SetActive(false);
        }

    }
}