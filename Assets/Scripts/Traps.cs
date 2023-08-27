using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener el componente PlayerMovement del jugador
            EthanTheHero.PlayerMovement player = other.GetComponent<EthanTheHero.PlayerMovement>();

            if (player != null)
            {
                // Llamar a la función Respawn del jugador para que este pueda respawnear
                player.Respawn();
            }
        }
    }
}
