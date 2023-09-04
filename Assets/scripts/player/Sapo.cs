using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sapo : MonoBehaviour
{
    Rigidbody2D fisica;
    bool ehTerreno; // condicional que permite pular
    private Rigidbody2D rb;
    public Collider2D sapoCollider; // O Collider do sapo para desativar temporariamente
    private bool isRotating = false;
    private Vector2 posicaoInicial;
    [SerializeField]
    public float velocidade; // Velocidade de movimento
    public float forcaPulo; // Força do salto
    [SerializeField]
    private GameObject imagemGameOver;
    private AudioSource sapoCoaxar;
    private ReiniciaJogo reiniciaJogo;

    public float distanciaPercorrida = 0;

    private Animator anim;

    private void Awake()
    {
        this.sapoCoaxar = this.GetComponent<AudioSource>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sapoCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        this.reiniciaJogo = GameObject.FindObjectOfType<ReiniciaJogo>();
        this.posicaoInicial = this.transform.position;
    }

    private void Update()
    {
        this.Andar();
        this.Pular();
        rb.freezeRotation = true;

        if (!ControladorCenario.CenarioPausado)
        {
            distanciaPercorrida += velocidade*Time.deltaTime;
        }
        if (isRotating)
        {
            transform.Rotate(Vector3.forward, 300 * Time.deltaTime); // Gira o sapo continuamente rapidamente
        }
    }

    private void Andar()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if(moveInput == 1)
        {
            rb.velocity = new Vector2(moveInput * this.velocidade, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * (this.velocidade - 1), rb.velocity.y);
        }
    }

    private void Pular()
    {
        if ((Input.GetKey(KeyCode.UpArrow)  || Input.GetKey(KeyCode.W)) && ehTerreno)
        {
            rb.velocity = new Vector2(rb.velocity.x, this.forcaPulo);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terreno"))
        {
            ehTerreno = true;
        }

        if (collision.gameObject.CompareTag("Morte"))
        {
            this.sapoCoaxar.Play();
            rb.AddForce(Vector2.up * this.forcaPulo, ForceMode2D.Impulse); // Impulsiona o sapo para cima ao morrer
            sapoCollider.enabled = false; // Desliga as colisoes do sapo
            isRotating = true; // Ativa a rotação contínua do sapo
            anim.enabled = false; // Para a animação no momento da morte
            
            // Pausar o cenário
            ControladorCenario.PausarCenario();

            // Habilitar a imagem de Game Over
            this.imagemGameOver.SetActive(true);

            GameObject musicaCorrida = GameObject.Find("MusicaCorrida");
            if (musicaCorrida != null)
            {
                AudioSource musicaCorridaAudioSource = musicaCorrida.GetComponent<AudioSource>();
                if (musicaCorridaAudioSource != null)
                {
                    musicaCorridaAudioSource.Stop();
                }
            }

            GeradorTerreno geradorTerreno = GameObject.FindObjectOfType<GeradorTerreno>();
            GeradorInimigos geradorInimigos = GameObject.FindObjectOfType<GeradorInimigos>();
            if (geradorTerreno != null)
            {
                geradorTerreno.PausarGerador();
                geradorInimigos.PausarGerador();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terreno"))
        {
            ehTerreno = false;
        }
    }

    public void Reiniciar()
    {
        rb.AddForce(Vector2.down * this.forcaPulo, ForceMode2D.Impulse);
        this.transform.position = this.posicaoInicial;
        this.transform.rotation = Quaternion.identity;
        sapoCollider.enabled = true;
        isRotating = false;
        anim.enabled = true;
        GameObject musicaCorrida = GameObject.Find("MusicaCorrida");
        if (musicaCorrida != null)
        {
            AudioSource musicaCorridaAudioSource = musicaCorrida.GetComponent<AudioSource>();
            if (musicaCorridaAudioSource != null)
            {
                musicaCorridaAudioSource.Play();
            }
        }
        GeradorTerreno geradorTerreno = GameObject.FindObjectOfType<GeradorTerreno>();
        GeradorInimigos geradorInimigos = GameObject.FindObjectOfType<GeradorInimigos>();
        if (geradorTerreno != null)
        {
            geradorTerreno.ContinuarGerador();
            geradorInimigos.ContinuarGerador();
        }
    }
}
