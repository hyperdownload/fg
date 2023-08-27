using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileController : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public float lifetime = 2f; // Tiempo de vida del proyectil en segundos
    public int damage = 10; // Daño del proyectil

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Aplica velocidad al proyectil en la dirección de su eje "forward" (derecha en 2D)
        rb.velocity = transform.right * speed;

        // Destruye el proyectil después de su tiempo de vida
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el proyectil colisiona con un enemigo, le causa daño y se destruye
        

        // Si el proyectil colisiona con el jugador, le causa daño y se destruye
        EthanTheHero.PlayerMovement player = collision.GetComponent<EthanTheHero.PlayerMovement>();
        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    public void Parry(){
        Destroy(gameObject);
    }
    public void SetDirectionAndDamage(Vector2 direction, int damage)
    {
        // Aplica la dirección y velocidad al proyectil
        rb.velocity = direction * speed;

        // Establece el daño del proyectil
        this.damage = damage;
    }
}
