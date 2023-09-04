using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMenu : MonoBehaviour
{
    [SerializeField] private float velocidade = 1.0f; // Velocidade do balanço
    [SerializeField] private float amplitude = 0.5f; // Amplitude do balanço

    private Vector3 posicaoInicial;

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        float deslocamentoVertical = amplitude * Mathf.Sin(Time.time * velocidade);
        transform.position = posicaoInicial + new Vector3(0, deslocamentoVertical, 0);
    }
}
