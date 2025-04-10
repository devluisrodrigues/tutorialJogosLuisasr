using UnityEngine;

public class catMovement : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float speed = 3.5f; 

    void Update()
    {
        if (player != null)
        {
            // Calcula a direção para o jogador
            Vector3 direction = (player.position - transform.position).normalized;

            // Move o gato na direção do jogador
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
