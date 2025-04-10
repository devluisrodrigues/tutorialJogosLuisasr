using UnityEngine;

public class cheese_lifetime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // O tempo de vida do queijo é de 5 segundos
    // A cada segundo ele deve ir escurecendo
    // Quando o tempo de vida chegar a 0, o queijo deve ser destruído
    public float tempoDeVida = 5f;
    private SpriteRenderer spriteRenderer;
    private float tempoDecorrido = 0f;

    public teste_generator cheeseGenerator;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        tempoDecorrido += Time.deltaTime;
        float porcentagem = tempoDecorrido / tempoDeVida;
        spriteRenderer.color = new Color(1- porcentagem/2, 1 - porcentagem/2, 1 - porcentagem/2);

        if (tempoDecorrido >= tempoDeVida)
        {
            Destroy(gameObject);
            cheeseGenerator.EstragarQueijo();
        }
    }
}

