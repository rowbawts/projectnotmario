using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float launchForce = 10f;
    public Vector3 direction = Vector3.forward;
    public Vector3 center = Vector3.zero;
    public Vector3 size = Vector3.one;
    private Rigidbody projectile;
    
    private void Awake()
    {
        projectile = GetComponent<Rigidbody>();

        projectile.AddForce(direction * launchForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a specific tag
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            // Code to execute when collision occurs
            Destroy(gameObject);
        }
    }
}
