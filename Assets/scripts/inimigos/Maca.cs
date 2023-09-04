using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maca : MonoBehaviour
{
    [SerializeField] private float velocidadeDeQueda = 2.0f;
    [SerializeField] private float tempoMinimoParado = 1.0f;
    [SerializeField] private float tempoMaximoParado = 3.0f;
    [SerializeField] private float duracaoDaSacudida = 0.5f;
    [SerializeField] private float intensidadeDaSacudida = 0.1f;

    private Vector3 posicaoInicial;
    private Vector3 posicaoSacudida;
    private bool estaMovendo = false;
    private bool estaParada = false;
    private bool estaSacudindo = false;
    private bool caindo = false;
    private float tempoDeParada;
    private float tempoDeInicioSacudida;
    private bool somCaindoTocado = false;
    private AudioSource quedaMacaAudioSource;

    private float tempoDeEspera;
    private bool aguardandoInicio = true;

    private void Start()
    {
        posicaoInicial = transform.position;
        posicaoSacudida = posicaoInicial;
        quedaMacaAudioSource = GameObject.Find("QuedaMaca").GetComponent<AudioSource>();

        tempoDeEspera = Time.time + Random.Range(tempoMinimoParado, tempoMaximoParado);
    }

    private void Update()
    {
        if (aguardandoInicio)
        {
            if (Time.time >= tempoDeEspera)
            {
                aguardandoInicio = false;
                estaMovendo = true;
                estaParada = false;
            }
        }
        else if (estaMovendo)
        {
            Mover();
        }
        else if (estaParada)
        {
            if (Time.time - tempoDeParada >= tempoMaximoParado)
            {
                estaParada = false;
                estaSacudindo = true;
                tempoDeInicioSacudida = Time.time;
                posicaoSacudida = transform.position;
            }
        }
        else if (estaSacudindo)
        {
            Sacudir();
        }
        else if (caindo)
        {
            Cair();
        }
    }

    private void Mover()
    {
        if (Camera.main.WorldToViewportPoint(transform.position).x > 0)
        {
            estaMovendo = false;
            estaParada = true;
            tempoDeParada = Time.time;
        }
    }

    private void Sacudir()
    {
        if (Time.time - tempoDeInicioSacudida < duracaoDaSacudida)
        {
            Vector3 deslocamento = new Vector3(Random.Range(-intensidadeDaSacudida, intensidadeDaSacudida), 0, 0);
            transform.position = posicaoSacudida + deslocamento;
        }
        else
        {
            estaSacudindo = false;
            caindo = true;
        }
    }

    private void Cair()
    {
        if (!somCaindoTocado)
        {
            quedaMacaAudioSource.Play();
            somCaindoTocado = true;
        }

        posicaoInicial = transform.position;
        transform.Translate(Vector3.down * velocidadeDeQueda * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destruir();
    }

    public void Destruir()
    {
        Destroy(gameObject);
    }
}
