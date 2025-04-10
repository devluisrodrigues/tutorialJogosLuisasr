using UnityEngine;
using TMPro;

public class teste_generator : MonoBehaviour
{
    public GameObject cheese_prefab; 

    public GameObject cat_prefab;
    public int quantidadeMaxima = 5; 
    public float intervaloSpawn = 3f;

    public float intervaloSpawnCat = 10f;

    public int quantidadeMaximaCat = 3;

    private int catsAtuais = 0;

    public Vector2 areaMin = new Vector2(-8.7f, -4.5f);
    public Vector2 areaMax = new Vector2(8.7f, 4.5f);

    private int queijosAtuais = 0;


    // Texto para controle do Score:
    private static int score = 0;

    private static float gameTime = 0f; 

    public static TextMeshProUGUI scoreText;

    public static TextMeshProUGUI contadorTempo;


    // Controle do Score
    public static void AddScore(int points) {
        score += points;
        Debug.Log("Score: " + score); // Log para verificar o score
        UpdateScoreText(); // Atualiza o texto na tela
    }

    public static void ResetScore() {
        score = 0;
        UpdateScoreText(); // Atualiza o texto na tela
    }

    private static void UpdateScoreText() {
        if (scoreText != null) {
            scoreText.text = "Score: " + score; // Atualiza o texto
        }
    }

    // Controle do Tempo
    public static void UpdateGameTime(float deltaTime) {
        gameTime += deltaTime;
        if (contadorTempo != null) {
            contadorTempo.text = "Tempo: " + gameTime.ToString("F2") + "s"; // Atualiza o texto
        }
    }
    public static void ResetGameTime() {
        gameTime = 0f;
        if (contadorTempo != null) {
            contadorTempo.text = "Tempo: " + gameTime.ToString("F2") + "s"; // Atualiza o texto
        }
    }

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("ScoreText GameObject não encontrado.");
        }
        contadorTempo = GameObject.Find("ContadorTempo").GetComponent<TextMeshProUGUI>();
        if (contadorTempo == null)
        {
            Debug.LogError("ContadorTempo GameObject não encontrado.");
        }
        InvokeRepeating("SpawnCheese", 0, intervaloSpawn);
        InvokeRepeating("SpawnCat", 5, intervaloSpawnCat);
        score = 0; 
        gameTime = 0f;
        queijosAtuais = 0;
        catsAtuais = 0;
        UpdateScoreText(); // Inicializa o texto do score
        ResetGameTime(); // Inicializa o tempo
    }

    void Update()
    {
        UpdateGameTime(Time.deltaTime); // Atualiza o tempo de jogo
        if (GameController.gameOver)
        {
            CancelInvoke("SpawnCheese");
            CancelInvoke("SpawnCat");
        }
    }


    void SpawnCheese()
    {
        if (queijosAtuais < quantidadeMaxima)
        {
            queijosAtuais++;
            Vector2 posicao = new Vector2(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y));
            GameObject cheese = Instantiate(cheese_prefab, posicao, Quaternion.identity);

            cheese_lifetime cheeseLifetime = cheese.GetComponent<cheese_lifetime>();
            cheeseLifetime.cheeseGenerator = this;
        }
    }

    void SpawnCat()
    {
        if (catsAtuais >= quantidadeMaximaCat)
        {
            return; 
        }
        Vector2 posicao;

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject with tag 'Player' is missing. Please ensure a GameObject in the scene has the 'Player' tag.");
            return;
        }

        float minDistanceFromPlayer = 3f;
        do
        {
            posicao = new Vector2(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y));
        } while (Vector2.Distance(posicao, player.transform.position) < minDistanceFromPlayer);

        GameObject cat = Instantiate(cat_prefab, posicao, Quaternion.identity);
        catMovement catMovementScript = cat.GetComponent<catMovement>();

        if (catMovementScript != null)
        {
            catMovementScript.player = player.transform;
        }
        catsAtuais++;

    }

   public void EstragarQueijo()
    {
        queijosAtuais--;
        if (queijosAtuais < 0)
        {
            queijosAtuais = 0;
        }
    }

    public void DecrementarQueijo()
    {
        queijosAtuais--;
        if (queijosAtuais < 0)
        {
            queijosAtuais = 0;
        }
        AddScore(1); 
    }

    public void IncrementarQueijo()
    {
        queijosAtuais++;
    }
}
