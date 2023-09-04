using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuvemDeMoscas : MonoBehaviour
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
        // Usar a função seno para gerar o movimento oscilatório
        float deslocamentoVertical = amplitude * Mathf.Sin(Time.time * velocidade);

        // Aplicar o deslocamento à posição da nuvem
        transform.position = posicaoInicial + new Vector3(0, deslocamentoVertical, 0);
    }
}
