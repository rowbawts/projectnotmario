using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float launchForce = 10f;
    private Rigidbody bullet;
    
    void Awake()
    {
        bullet = GetComponent<Rigidbody>();

        bullet.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
    }
}
