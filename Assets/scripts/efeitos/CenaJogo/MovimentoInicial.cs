using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInicial : MonoBehaviour
{
    [SerializeField]
    private float velocidade; // Velocidade da plataforma
    private Vector2 posTerrenoInicial;
    private ReiniciaJogo reiniciaJogo;

    private void Start()
    {
        this.posTerrenoInicial = this.transform.position;
        this.reiniciaJogo = GameObject.FindObjectOfType<ReiniciaJogo>();
    }

    void Update()
    {
        if (!ControladorCenario.CenarioPausado)
        {
            this.transform.Translate(Vector2.left * this.velocidade * Time.deltaTime);
        }
    }

    public void Reiniciar()
    {
        this.transform.position = this.posTerrenoInicial;
    }


}
