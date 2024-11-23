
using UnityEngine;
using UnityEngine.UI;
public class coolerballscript : MonoBehaviour
{
    public float angle = 45f;  // launch angle (in degrees)
    public float velocity = 5f;   // Initial velocity for ball
    float maxV = 10f; // maximum velocity
    float minV = 1f;  // minimum velocity
    public Text uiText;
    public Text VText;
    void Update()
    {
        rotateMouse();
        uiText.text = "Launch Angle: " + angle.ToString();
        VText.text = "Launch Velocity: " + velocity.ToString();
        // adjust Initial velocity with A and D key
        if (Input.GetKeyDown(KeyCode.D)) // increases the v by 1
        {
            velocity += 1f;
            velocity = Mathf.Clamp(velocity, minV, maxV); // stores value after adjustment
        }
        if (Input.GetKeyDown(KeyCode.A)) // decreases the v by 1
        {
            velocity -= 1f;
            velocity = Mathf.Clamp(velocity, minV, maxV); // stores valuep after adjustment
        }

    }

    //Make the emitter follow the mouse rotation and clamp the angle between 0 to 90 degrees
    void rotateMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set the Z component to 0 since we're in 2D
        mousePosition.z = 0;

        // Get the direction to the mouse
        Vector3 direction = mousePosition - transform.position;

        // Calculate the rotation angle in radians
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Clamp the angle between 0 and 90 degrees
        angle = Mathf.Clamp(angle, 0f, 90f);

        // Apply the rotation
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

}
