using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        // Realizar un raycast desde la posición deseada de la cámara hacia el objetivo
        RaycastHit hit;
        if (Physics.Raycast(target.position, -offset.normalized, out hit, offset.magnitude))
        {
            // Si el raycast choca con un objeto, ajustar la posición deseada de la cámara
            desiredPosition = hit.point;
        }

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
