using UnityEngine;

public class teste_generator : MonoBehaviour
{
    public GameObject cheese_prefab; 
    public int quantidadeMaxima = 5; 
    public float intervaloSpawn = 3f; 
    public Vector2 areaMin = new Vector2(-9, -4.5f);
    public Vector2 areaMax = new Vector2(9, 4.5f);

    private int queijosAtuais = 1;

    void Start()
    {
        InvokeRepeating("SpawnCheese", 0, intervaloSpawn);
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

    public void DecrementarQueijo()
    {
        queijosAtuais--;
    }

    public void IncrementarQueijo()
    {
        queijosAtuais++;
    }
}
