using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigos: MonoBehaviour
{
    [SerializeField]
    private float tempoGera;
    private float cronometro;

    [SerializeField]
    private GameObject objetoInimigo;

    [SerializeField]
    private float intervaloMinimo;
    [SerializeField]
    private float intervaloMaximo;
    private float tempoProximaGeracao;
    private bool jogoPausado = false;

    private void Awake()
    {
        this.cronometro = this.tempoGera;
        DefinirProximaGeracao();
    }

    void Update()
    {
        if (!jogoPausado)
        {
            this.cronometro -= Time.deltaTime;

            if (this.cronometro < 0)
            {
                GameObject.Instantiate(objetoInimigo, this.transform.position, Quaternion.identity);
                DefinirProximaGeracao();
                this.cronometro = this.tempoGera;
            }
        }
    }

    void DefinirProximaGeracao()
    {
        tempoProximaGeracao = Time.time + Random.Range(intervaloMinimo, intervaloMaximo);
    }

    public void PausarGerador()
    {
        jogoPausado = true;
    }

    public void ContinuarGerador()
    {
        jogoPausado = false;
    }
}
