using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Configurações de Tempo")]
    public float tempoRestante = 60f; 
    public Text textoCronometro;

    [Header("Configurações de Pontos")]
    public Text textoPontosHUD;
    public Text textoPontosFinal; 
    private int inimigosEliminados = 0;

    [Header("Painéis de UI")]
    public GameObject painelGameOver;   
    public GameObject painelFimDeTempo; 

    private bool jogoAtivo = true;

    void Update()
    {
        if (!jogoAtivo) return;

        // Atualiza o cronômetro
        if (tempoRestante > 0)
        {
            tempoRestante -= Time.deltaTime;
            AtualizarUI();
        }
        else
        {
            FinalizarPorTempo();
        }
    }

    void AtualizarUI()
    {
        textoCronometro.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(tempoRestante / 60), Mathf.FloorToInt(tempoRestante % 60));
        textoPontosHUD.text = "Inimigos: " + inimigosEliminados;
    }

    public void AdicionarMorteInimigo()
    {
        if (!jogoAtivo) return;
        inimigosEliminados++;
    }

    // Chamado pelo PlayerController quando ele morre
    public void PlayerMorreu()
    {
        jogoAtivo = false;
        Time.timeScale = 0f;
        painelGameOver.SetActive(true);
    }

    void FinalizarPorTempo()
    {
        jogoAtivo = false;
        Time.timeScale = 0f;
        tempoRestante = 0;

        painelFimDeTempo.SetActive(true);
        textoPontosFinal.text = "Você eliminou " + inimigosEliminados + " inimigos!";
    }

    // Funções dos Botões
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrParaMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}