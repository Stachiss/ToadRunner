using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aguia : MonoBehaviour
{
    private bool aguiaVisivel = false;
    private bool paradaIniciada = false;
    private bool lancamentoIniciado = false;
    private Vector3 posicaoInicial;
    private Vector3 posicaoSapoInicial;
    [SerializeField]
    private float velocidadeLancamento = 10.0f;
    [SerializeField]
    private float tempoParado;
    [SerializeField]
    private AudioSource aguiaGrasno;

    private void Awake()
    {
        posicaoInicial = transform.position;
    }

    private void Update()
    {
        if (aguiaVisivel)
        {
            if (!paradaIniciada)
            {
                if (tempoParado <= 0)
                {
                    this.aguiaGrasno.Play();
                    IniciarLancamento();
                }
                else
                {
                    tempoParado -= Time.deltaTime;
                }
            }
            else if (!lancamentoIniciado)
            {
                Vector3 direcaoLancamento = (posicaoSapoInicial - posicaoInicial).normalized;
                Vector3 novaPosicao = transform.position + direcaoLancamento * velocidadeLancamento * Time.deltaTime;
                transform.position = novaPosicao;

                if (Vector3.Distance(transform.position, posicaoSapoInicial) < 0.1f)
                {
                    lancamentoIniciado = true;
                }
            }
        }
    }

    private void IniciarLancamento()
    {
        paradaIniciada = true;
        posicaoSapoInicial = GameObject.FindGameObjectWithTag("Sapo").transform.position;
    }

    private void OnBecameVisible()
    {
        aguiaVisivel = true;
    }

    private void OnBecameInvisible()
    {
        if (lancamentoIniciado)
        {
            lancamentoIniciado = false;
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        this.Destruir();
    }

    public void Destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
