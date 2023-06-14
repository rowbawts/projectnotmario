using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ChatGPT made this lol
public class ShipController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fireRate = 0.5f;
    public int health = 3;
    public Text healthText;
    public GameObject cannon;
    public GameObject bulletPrefab;
    private Vector3 bulletSpawnVector;
    private Vector3 moveVector;
    private float nextFireTime;
    private Rigidbody ship;
    private AudioSource audioSource;

    private void Awake()
    {
        // Get the ship's rigidbody component & audio source component
        ship = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        move();
        shoot();

        // Update the health text
        healthText.text = "Health: " + health.ToString();

        // Check if the ship has no health
        if (health == 0)
        {
            // Destroy the ship
            Destroy(gameObject);
        }
    }

    private void move()
    {
        // Get input axes
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        // Calculate movement vector
        moveVector = playerInput * moveSpeed;

        // Apply movement to the rigidbody
        ship.MovePosition(ship.position + moveVector * Time.fixedDeltaTime);
    }

    private void shoot()
    {
        // Check if the spacebar is pressed and if the fire rate delay has passed
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime) {
            // Create vector to spawn bullet and tip of cannon
            bulletSpawnVector = new Vector3(cannon.transform.position.x, 0f, cannon.transform.position.z);
            
            // Spawn the projectile prefab & play the associated sound file
            GameObject spawnedPrefab = Instantiate(bulletPrefab, bulletSpawnVector, Quaternion.identity);
            audioSource.Play();

            // Create delay for fire rate of cannon
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a specific tag
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Bullet"))
        {
            // Code to execute when collision occurs
            health -= 1;
        }
    }
}
