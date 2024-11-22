
using UnityEngine;

public class coolerballscript : MonoBehaviour
{
    public float angle = 45f;  // launch angle (in degrees)
    public float force = 5f;   // launch force
    public float maxForce = 10f; // maximum force
    public float minForce = 1f;  // minimum force

    void Update()
    {
        //mathf.clamp works by setignthe maxinum and min values that can be use and once the user enters the desited value withing the max-min it will store the value to use later

        // adjust the angle using the w and s keys
        if (Input.GetKeyDown(KeyCode.W)) // increases the angle by 5 degrees
        {
            angle += 5f;
            angle = Mathf.Clamp(angle, 0f, 90f); // stores value after adjustment
        }
        if (Input.GetKeyDown(KeyCode.S)) // decreases the angle by 5 degrees
        {
            angle -= 5f;
            angle = Mathf.Clamp(angle, 0f, 90f); // Clamp after adjustment
        }


        // adjust force using the a and Ddkeys
        if (Input.GetKeyDown(KeyCode.D)) // increases tthe force by 1
        {
            force += 1f;
            force = Mathf.Clamp(force, minForce, maxForce); // stores value after adjustment
        }
        if (Input.GetKeyDown(KeyCode.A)) // decreases the force by 1
        {
            force -= 1f;
            force = Mathf.Clamp(force, minForce, maxForce); // stores valuep after adjustment
        }

        // prints the current angle and force values into the console
        Debug.Log("Angle: " + angle + ", Force: " + force);
    }
}
