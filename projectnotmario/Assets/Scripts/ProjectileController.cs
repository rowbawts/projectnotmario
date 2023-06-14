using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float launchForce = 10f;
    public Vector3 direction = Vector3.forward;
    private Rigidbody bullet;
    
    void Awake()
    {
        bullet = GetComponent<Rigidbody>();

        bullet.AddForce(direction * launchForce, ForceMode.Impulse);
    }
}
