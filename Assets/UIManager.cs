using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject endGamePanel;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (GameController.gameOver)
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0; // Pausa o jogo
        }
    }
}
