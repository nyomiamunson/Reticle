using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 1f;
    [SerializeField] GameObject cloudPrefab; // Prefab of the cloud to be spawned
    private float screenWidth;
    private float spriteWidth;
    private bool hasSpawnedNewCloud = false;

    // Start is called before the first frame update
    void Start()
    {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        screenWidth = Camera.main.aspect * Camera.main.orthographicSize * 2f;

        // Position the clouds initially to appear at the edge of the screen
        transform.position = new Vector3(-screenWidth / 2f - spriteWidth / 2f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the cloud horizontally based on scroll speed
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);

        // If cloud moves past the screen, reposition it to the other side
        if (transform.position.x > screenWidth / 2f + spriteWidth / 2f)
        {
            // Position the cloud just outside the screen on the opposite side
            transform.position = new Vector3(-screenWidth / 2f - spriteWidth / 2f, transform.position.y, transform.position.z);
            hasSpawnedNewCloud = false; // Reset flag to allow spawning of a new cloud
        }

        // If the cloud is halfway through the screen and a new cloud hasn't been spawned yet, spawn one
        if (!hasSpawnedNewCloud && transform.position.x > 0)
        {
            SpawnCloud();
            hasSpawnedNewCloud = true;
        }
    }

    // Method to spawn a new cloud on top of the current one
    private void SpawnCloud()
    {
        float newYPosition = transform.position.y + spriteWidth / 2f; // Spawn the new cloud just above the current cloud
        Instantiate(cloudPrefab, new Vector3(transform.position.x, newYPosition, transform.position.z), Quaternion.identity);
    }
}