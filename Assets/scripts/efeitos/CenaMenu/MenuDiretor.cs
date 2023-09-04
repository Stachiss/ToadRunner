using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDiretor : MonoBehaviour
{
    [SerializeField] private string cenaJogo;
    [SerializeField] private GameObject painelMenu;
    [SerializeField] private GameObject painelCreditos;
    [SerializeField] public AudioSource musicaMenu;

    public void Jogar()
    {
        musicaMenu.enabled = false;
        SceneManager.LoadScene(cenaJogo);
    }

    public void AbrirCreditos()
    {
        painelMenu.SetActive(false);
        painelCreditos.SetActive(true);
    }

    public void FecharCreditos()
    {
        painelMenu.SetActive(true);
        painelCreditos.SetActive(false);
    }

    public void Sair()
    {
            Debug.Log("Saiu!");
            Application.Quit();
    }
}
