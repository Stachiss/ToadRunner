using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NuvemDeMoscas : MonoBehaviour
{
    [SerializeField] private float velocidade = 1.0f; // Velocidade do balan�o
    [SerializeField] private float amplitude = 0.5f; // Amplitude do balan�o

    private Vector3 posicaoInicial;

    private void Start()
    {
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        // Usar a fun��o seno para gerar o movimento oscilat�rio
        float deslocamentoVertical = amplitude * Mathf.Sin(Time.time * velocidade);

        // Aplicar o deslocamento � posi��o da nuvem
        transform.position = posicaoInicial + new Vector3(0, deslocamentoVertical, 0);
    }
}
