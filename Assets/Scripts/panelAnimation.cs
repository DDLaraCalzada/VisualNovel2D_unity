using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelAnimation : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Salir");
        yield return new WaitForSeconds(animacionFinal.length);


    }
}
