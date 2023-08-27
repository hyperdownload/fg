using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 10.0f;
    public float smoothSpeed = 5.0f; // Velocidad de suavizado del movimiento de la cámara
    public Vector3 cameraOffset; // Offset de la cámara con respecto al jugador

    private Transform player;
    private Transform cameraTransform;

    private void Start()
    {
        player = transform; // Suponemos que este script está en el jugador
        cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + cameraOffset;
        RaycastHit hit;

        if (Physics.Raycast(player.position, cameraOffset, out hit, maxDistance))
        {
            if (hit.distance < minDistance && hit.collider.CompareTag("CameraColleable"))
            {
                desiredPosition = player.position + cameraOffset.normalized * minDistance;
            }
            else if (hit.collider.CompareTag("CameraColleable"))
            {
                desiredPosition = player.position + cameraOffset.normalized * hit.distance;
            }
        }

        // Suavemente mueve la cámara hacia la posición deseada
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
    }
}
