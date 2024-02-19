using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public AudioSource audioSource;

    // Define bounds for movement (adjust as needed)
    float minX = -6.8f;  // Left bound
    float maxX = 8.7f;   // Right bound
    float minY = -6f; // Bottom bound
    float maxY = 3.5f; // Top bound

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = Vector3.right * horizontalInput * speed * Time.deltaTime;
        transform.Translate(horizontalMovement);
        // Clamp horizontal position
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);

        // Vertical movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 verticalMovement = Vector3.up * verticalInput * speed * Time.deltaTime;
        transform.Translate(verticalMovement);
        // Clamp vertical position
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);

        // Firing sound
        AudioSource audioSource; //Delcare a AudioSource reference variable
        audioSource = GetComponent<AudioSource>(); //Get a reference to our AudioSource
        if (Input.GetKeyDown("space"))
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
