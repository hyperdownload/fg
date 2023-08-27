using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] private Transform hitController;
    [SerializeField] private float hitRadius;
    [SerializeField] private float hitDamage;
    private void Update(){
        if (Input.GetButtonDown("Fire1"))hit();
    }
    private void hit(){
        Collider2D[] objects = Physics2D.OverlapCircleAll(hitController.position, hitRadius);
        foreach (Collider2D collisioner in objects){
            if (collisioner.CompareTag("Enemy")) collisioner.transform.GetComponent<EnemyIA>().TakeDamage(hitDamage);
            if (collisioner.CompareTag("Proyectile")) collisioner.transform.GetComponent<ProyectileController>().Parry();
        }
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(hitController.position, hitRadius);
    }
}
