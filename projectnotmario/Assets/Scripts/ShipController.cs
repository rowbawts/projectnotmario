using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ChatGPT made this lol
public class ShipController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fireRate = 0.5f;
    public GameObject cannon;
    public GameObject bulletPrefab;
    private Vector3 bulletSpawnVector;
    private Vector3 moveVector;
    private float nextFireTime;
    private Rigidbody ship;

    private void Awake() {
        // Get ship's rigidbody component
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update() {
        move();
        shoot();
    }

    private void move() {
        // Get input axes
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        // Calculate movement vector
        moveVector = playerInput * moveSpeed;

        // Apply movement to the rigidbody
        ship.MovePosition(ship.position + moveVector * Time.fixedDeltaTime);
    }

    private void shoot() {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime) {
            // Create vector to spawn bullet and tip of cannon
            bulletSpawnVector = new Vector3(cannon.transform.position.x, 0f, cannon.transform.position.z);
            
            // Spawn the prefab
            GameObject spawnedPrefab = Instantiate(bulletPrefab, bulletSpawnVector, Quaternion.identity);

            nextFireTime = Time.time + fireRate;
        }
    }
}
