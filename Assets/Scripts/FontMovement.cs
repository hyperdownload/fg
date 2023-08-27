using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontMovement : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMovimiento;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D player;
    private void Awake() {
        material = GetComponent<SpriteRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        offset=(player.velocity.x*0.1f)*velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset+=offset;
    }
}
