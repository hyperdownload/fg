using UnityEngine;

public class Checkpoint2D : MonoBehaviour
{
    private Vector2 checkpointPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EthanTheHero.PlayerMovement character = other.GetComponent<EthanTheHero.PlayerMovement>();
            if (character != null)
            {
                character.SetCheckpoint(this);
                UpdateCheckpointPosition(other.transform.position);
            }
        }
    }

    public void UpdateCheckpointPosition(Vector2 position)
    {
        // Solo actualizamos la posición del checkpoint si es más alta que la posición actual
        if (position.y > checkpointPosition.y)
        {
            checkpointPosition = position;
        }
    }

    // Cambio de FixedUpdate a LateUpdate para asegurar que se actualice después de todos los movimientos del jugador
    private void LateUpdate()
    {
        // Mantener la posición en el eje X del checkpoint, solo actualizar en el eje Y
        checkpointPosition.y = Mathf.Max(checkpointPosition.y, transform.position.y);
    }

    public Vector2 GetCheckpointPosition()
    {
        return checkpointPosition;
    }
}
