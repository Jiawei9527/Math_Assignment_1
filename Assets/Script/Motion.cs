using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    float initialVelocity = 5f; // Initial speed in units per second
    float launchAngle = 45f;    // Launch angle in degrees
    float gravity = -9.81f;     // Gravity (negative for downward pull)
    float timeElapsed = 0f;
    Vector3 startPosition;
    bool isLaunched = false;
    public coolerballscript square;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for left mouse click to launch the projectile
        if (Input.GetMouseButtonDown(0) && !isLaunched) // 0 = Left Mouse Button
        {
            Launch();
        }

        BeforeLaunch();
        BallMotion();
    }


    //projectile motion
    void BallMotion()
    {
        if (square != null && isLaunched == true)
        {
            timeElapsed += Time.deltaTime;

            // Calculate position based on projectile motion formula
            float radianAngle = Mathf.Deg2Rad * launchAngle; // Convert angle to radians
            float x = initialVelocity * timeElapsed * Mathf.Cos(radianAngle); // Horizontal displacement
            float y = (initialVelocity * Mathf.Sin(radianAngle) * timeElapsed) + (0.5f * gravity * Mathf.Pow(timeElapsed, 2)); // Vertical displacement

            // Update the position of the object
            transform.position = startPosition + new Vector3(x, y, 0);

            // Stop simulation if the object goes below its starting height
            if (transform.position.y < -3.7f)
            {
                ResetProjectile();
            }

        }
    }

    //Ball is stick on the launcher before it launched.
    void BeforeLaunch()
    {
        if (square != null && isLaunched == false)
        {
            // Calculate the right edge position relative to the square
            Vector3 rightEdgePosition = square.transform.position + square.transform.right;

            // Set the object's position to the right edge
            transform.position = rightEdgePosition;

        }

    }

    void Launch()
    {
        initialVelocity = square.velocity;
        launchAngle = square.angle;
        timeElapsed = 0f;  // Reset the timer
        startPosition = transform.position; // Set current position as the starting point
        isLaunched = true; // Start the motion
    }

    void ResetProjectile()
    {
        isLaunched = false; // Stop the motion

    }
}
