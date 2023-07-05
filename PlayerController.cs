using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManager

public class PlayerController : MonoBehaviour
{
    // Variables
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    // Gyroscope Variables
    bool gyroSupported;
    private Gyroscope gyro;
    float shakeThreshold;

    private void Awake()
    {
        gyro = Input.gyro;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
            gyroSupported = true;
        }            
    }

    // Update is called once per frame
    void Update()
    {
        // Jump, 0 = left mouse button
        if ((Input.GetMouseButtonDown(0) || IsDeviceShaking()) && canJump) 
        { 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Detect if device is shaking via gyroscope
    private bool IsDeviceShaking()
    {
        if (!gyroSupported || gyro == null)
            return false;

        shakeThreshold = 0.001f; // Adjust to control sensitivity of shake detection
        Vector3 rotationRate = gyro.rotationRate;

        return rotationRate.sqrMagnitude >= shakeThreshold * shakeThreshold;
    }

    // When the player is on an object (i.e. the ground)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    // When the player is in the air (i.e. jumping)
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    // When the player collides with another object's collider
    private void OnTriggerEnter(Collider other)
    {
        // Restart the scene upon collision
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
            Debug.Log("Collision detected");
        }
    }
}
