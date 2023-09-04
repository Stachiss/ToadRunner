using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaDistancia : MonoBehaviour
{
    Sapo sapo;
    Text distanciaTexto;

    private void Awake()
    {
        sapo = GameObject.Find("Sapo").GetComponent<Sapo>();
        distanciaTexto = GameObject.Find("Distancia").GetComponent<Text>();
    }

    void Update()
    {
        int distancia = Mathf.FloorToInt(sapo.distanciaPercorrida);
        distanciaTexto.text = distancia + " m";
    }

    public void Reiniciar()
    {
        int distancia = 0;
        distanciaTexto.text = distancia + " m";

        sapo.distanciaPercorrida = 0;
    }
}
