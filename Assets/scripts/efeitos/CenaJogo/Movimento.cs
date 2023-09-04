using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField]
    public float velocidade; // Velocidade da plataforma
    [SerializeField]
    private float variacaoPosicaoY;
    [SerializeField]
    private float variacaoPosicaoX_minima;
    [SerializeField]
    private float variacaoPosicaoX_maxima;
    [SerializeField]
    private float variacaoTamanhoX;

    private void Awake()
    {
        // Armazena o tamanho original da plataforma
        Vector3 tamanhoOriginal = transform.localScale;

        // Aplica a variação no tamanho do eixo X
        float novoTamanhoX = Random.Range(tamanhoOriginal.x - variacaoTamanhoX, tamanhoOriginal.x + variacaoTamanhoX);
        Vector3 novoTamanho = new Vector3(novoTamanhoX, tamanhoOriginal.y, tamanhoOriginal.z);
        transform.localScale = novoTamanho;

        // Aplica a variação na posição do eixo Y e do eixo X
        this.transform.Translate(Vector2.up * Random.Range(-variacaoPosicaoY, variacaoPosicaoY));
        this.transform.Translate(Vector2.right * Random.Range(variacaoPosicaoX_minima, variacaoPosicaoX_maxima));
    }
    void Update()
    {
        if (!ControladorCenario.CenarioPausado)
        {
            this.transform.Translate(Vector2.left * this.velocidade * Time.deltaTime);
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
