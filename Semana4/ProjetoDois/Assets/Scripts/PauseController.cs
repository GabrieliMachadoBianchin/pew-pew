using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseController : MonoBehaviour
{
    public GameObject painelPause; 
    private bool jogoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (jogoPausado)
                Continuar();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        painelPause.SetActive(true); 
        Time.timeScale = 0f;        // Congela o tempo do jogo
        jogoPausado = true;
    }

    public void Continuar()
    {
        painelPause.SetActive(false); 
        Time.timeScale = 1f;         
        jogoPausado = false;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrParaMenuInicial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
}