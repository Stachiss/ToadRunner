using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciaJogo : MonoBehaviour
{
    private Sapo sapo;
    private Maca maca;
    private Aguia aguia;
    private MovimentoInicial movIni;
    private ControlaDistancia distancia;
    [SerializeField] private GameObject imagemGameOver;
    [SerializeField] private string cenaMenu;


    private void Start()
    {
        this.sapo = GameObject.FindObjectOfType<Sapo>();
        this.movIni = GameObject.FindObjectOfType<MovimentoInicial>();
        this.distancia = GameObject.FindObjectOfType<ControlaDistancia>();
    }
    public void Update()
    {
        if (ControladorCenario.CenarioPausado)
        {
            if (Input.GetKey(KeyCode.R))
            {
                ResetaJogo();
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                ResetaJogo();
                SceneManager.LoadScene(cenaMenu);
            }
        }
    }

    public void ResetaJogo()
    {
        imagemGameOver.SetActive(false);
        this.ResetarObstaculos();
        ControladorCenario.CenarioPausado = false;
        this.sapo.Reiniciar();
        this.movIni.Reiniciar();
        this.distancia.Reiniciar();
    }

    private void ResetarObstaculos()
    {
        Movimento[] movimentos = GameObject.FindObjectsOfType<Movimento>();
        foreach (Movimento movimento in movimentos)
        {
            movimento.Destruir();
        }

        MovimentoInicial[] terrenos = GameObject.FindObjectsOfType<MovimentoInicial>();
        foreach (MovimentoInicial terreno in terrenos)
        {
            terreno.Reiniciar();
        }

        Maca[] macas = GameObject.FindObjectsOfType<Maca>();
        foreach (Maca maca in macas)
        {
            maca.Destruir();
        }

        Aguia[] aguias = GameObject.FindObjectsOfType<Aguia>();
        foreach (Aguia aguia in aguias)
        {
            aguia.Destruir();
        }
    }
}
