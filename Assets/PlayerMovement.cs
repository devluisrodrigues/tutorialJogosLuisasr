using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5.0f;

    public teste_generator cheeseGenerator;

    private bool facingRight = true; // Variável para rastrear a direção
    new AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (moveHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveHorizontal < 0 && facingRight)
        {
            Flip();
        }

        rb.MovePosition(rb.position + movement.normalized * Time.fixedDeltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            audio.Play();
            Destroy(other.gameObject);
            cheeseGenerator.DecrementarQueijo();
            GameController.collect();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1; // Apenas espelha no eixo X
        transform.localScale = newScale;
    }

    void UpdateSpriteDirection(float x, float y)
    {
        Vector3 newScale = transform.localScale;

        // Definição das direções baseadas nos inputs
        if (x > 0) // Direita
        {
            newScale.x = Mathf.Abs(newScale.x);
        }
        else if (x < 0) // Esquerda (espelha no eixo X)
        {
            newScale.x = -Mathf.Abs(newScale.x);
        }

        if (y > 0) // Para cima (espelha no eixo Y)
        {
            newScale.y = -Mathf.Abs(newScale.y);
        }
        else if (y < 0) // Para baixo (normaliza o Y)
        {
            newScale.y = Mathf.Abs(newScale.y);
        }

        transform.localScale = newScale;
    }
}
