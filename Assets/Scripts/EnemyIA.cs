using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private float visionRange = 15f;
    [SerializeField] private float minDistanceToPlayer = 5f;
    [SerializeField] private float targetDistance = 8f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float attackInterval = 2f;
    [SerializeField] private float projectileSpeed = 10f;

    private float currentHealth;
    private Transform player;
    private Rigidbody2D rb;
    private float attackTimer = 0f;

    private enum EnemyState
    {
        Idle,
        Moving,
        Shooting
    }

    private EnemyState currentState = EnemyState.Idle;
    private Vector2 randomMovementDirection;
    private bool isMovingRandomly = false;
    private bool canShoot = true;
    private float timeSinceLastShot = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= visionRange)
            {
                RotateTowardsPlayer();

                if (currentState == EnemyState.Moving)
                {
                    MoveTowardsPlayer();

                    if (distanceToPlayer <= attackRange)
                    {
                        currentState = EnemyState.Shooting;
                    }
                }
                else if (currentState == EnemyState.Shooting)
                {
                    rb.velocity = Vector2.zero;
                    if (canShoot)
                    {
                        Shoot();
                        canShoot = false;
                        timeSinceLastShot = 0f;
                    }
                }
                else
                {
                    currentState = EnemyState.Moving;
                }
            }
            else
            {
                currentState = EnemyState.Idle;
                rb.velocity = Vector2.zero;

                if (!isMovingRandomly)
                {
                    StartCoroutine(StartRandomMovement());
                }
            }
        }

        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= attackInterval)
        {
            canShoot = true;
        }
    }

    private IEnumerator StartRandomMovement()
    {
        isMovingRandomly = true;
        float randomWaitTime = Random.Range(1f, 3f);
        yield return new WaitForSeconds(randomWaitTime);

        // Generate a random direction for movement
        randomMovementDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        isMovingRandomly = false;
        currentState = EnemyState.Moving;
    }

    private void RotateTowardsPlayer()
    {
        Vector2 directionToPlayer = player.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void MoveTowardsPlayer()
    {
        Vector2 directionToPlayer = player.position - transform.position;
        Vector2 moveDirection = directionToPlayer.normalized;
        rb.velocity = moveDirection * moveSpeed;
    }

    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Vector2 directionToPlayer = (player.position - firePoint.position).normalized;
            projectile.GetComponent<Rigidbody2D>().velocity = directionToPlayer * projectileSpeed;

            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
