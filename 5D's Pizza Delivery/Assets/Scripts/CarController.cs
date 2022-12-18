using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // The speed of the car
    public float speed = 10.0f;

    // The maximum speed the car can reach
    public float maxSpeed = 100.0f;

    // The acceleration of the car
    public float acceleration = 10.0f;

    // The deceleration of the car
    public float deceleration = 10.0f;

    // The turn speed of the car
    public float turnSpeed = 10.0f;

    // The rigidbody component of the car
    private Rigidbody2D rb;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the input axis values for the horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the current speed of the car
        float currentSpeed = rb.velocity.magnitude;

        // If the vertical input is positive, accelerate the car
        if (verticalInput > 0)
        {
            speed += acceleration * Time.deltaTime;

            // Clamp the speed to the max speed
            speed = Mathf.Clamp(speed, 0.0f, maxSpeed);
        }
        // If the vertical input is negative, decelerate the car
        else if (verticalInput < 0)
        {
            speed -= deceleration * Time.deltaTime;

            // Clamp the speed to 0
            speed = Mathf.Max(speed, 0.0f);
        }
        // If the vertical input is 0, maintain the current speed
        else
        {
            speed = currentSpeed;
        }

        // Rotate the car based on the horizontal input
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, -horizontalInput * turnSpeed * Time.deltaTime);

        // Set the velocity of the rigidbody based on the current speed and the forward direction of the car
        rb.velocity = transform.up * speed;
    }
}