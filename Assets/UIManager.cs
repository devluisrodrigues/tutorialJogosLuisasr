using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public GameObject endGamePanel;
    public GameObject player; // Referência ao Player
    public GameObject scoreText; // Referência ao Score_text
    public GameObject contadorTempo; // Referência ao contador_tempo

    public TextMeshProUGUI finalScoreText; // Referência ao texto final do Score
    public TextMeshProUGUI finalTimeText; // Referência ao texto final do Tempo

    void Start()
    {
        // Certifique-se de que o painel está desativado no início
        endGamePanel.SetActive(false);
    }

    void FixedUpdate()
    {
        if (GameController.gameOver)
        {
            Time.timeScale = 0;

            if (finalScoreText != null)
            {
                finalScoreText.text = teste_generator.scoreText.text;
            }

            if (finalTimeText != null)
            {
                finalTimeText.text = teste_generator.contadorTempo.text;
            }

            endGamePanel.SetActive(true);
            endGamePanel.transform.SetAsLastSibling(); 

            if (player != null)
                player.SetActive(false);

            if (scoreText != null)
                scoreText.SetActive(false);

            if (contadorTempo != null)
                contadorTempo.SetActive(false);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Inimigo");
            foreach (GameObject enemy in enemies)
            {
                if (enemy != null)
                    enemy.SetActive(false);
            }
            GameObject[] cheesePrefabs = GameObject.FindGameObjectsWithTag("Coletavel");
            foreach (GameObject cheese in cheesePrefabs)
            {
                if (cheese != null)
                    cheese.SetActive(false);
            }
        }
    }
}