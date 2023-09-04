using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorTerreno : MonoBehaviour
{
    [SerializeField]
    private float tempoGera;
    private float cronometro;
    [SerializeField]
    private GameObject objeto;
    private bool jogoPausado = false;
    private void Awake()
    {
        this.cronometro = this.tempoGera;
    }

    void Update()
    {
        if (!jogoPausado)
        {
            this.cronometro -= Time.deltaTime;

            if (this.cronometro < 0)
            {
                GameObject.Instantiate(objeto, this.transform.position, Quaternion.identity);
                this.cronometro = this.tempoGera;
            }
        }
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