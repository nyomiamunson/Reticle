using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public AudioSource audioSource;

    // Define bounds for movement (adjust as needed)
    [SerializeField] float minX = -6.8f; // Left bound
    [SerializeField] float maxX = 8.7f; // Right bound
    [SerializeField] float minY = -6f; // Bottom bound
    [SerializeField] float maxY = 3.5f; // Top bound
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float explosionDuration = 3f; // Duration of explosion before destruction
    [SerializeField] Vector3 explosionOffset; // Where the explosion explodes

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component once at the start
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = Vector3.right * horizontalInput * speed * Time.deltaTime;

        // Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 verticalMovement = Vector3.up * verticalInput * speed * Time.deltaTime;

        // Move the object
        transform.Translate(horizontalMovement + verticalMovement);

        // Clamp the position
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // Firing sound
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
            // Instantiate explosion at the intersection point
            GameObject explosion = Instantiate(explosionPrefab, transform.position + explosionOffset, transform.rotation);
            Destroy(explosion, 1f);
        }
    }
}