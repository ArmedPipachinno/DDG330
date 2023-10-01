using UnityEngine;

public class BatSwing : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float swingSpeed = 90f; // Speed at which the bat swings (degrees per second)
    public float swingRadius = 2f; // Radius of the circular swing path
    public float maxSwingAngle = 90f; // Maximum swing angle in degrees
    public float returnSpeed = 45f; // Speed at which the bat returns to the original position

    private Vector3 originalPosition; // Original position of the bat relative to the player
    private Quaternion originalRotation; // Original rotation of the bat relative to the player
    private bool isSwinging = false; // Flag to track if the bat is currently swinging
    private bool isReturning = false; // Flag to track if the bat is returning to the original position
    private float currentSwingAngle = 0f; // Current swing angle

    private void Start()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    private void Update()
    {
        // Check for input to start swinging
        if (Input.GetMouseButtonDown(0) && !isSwinging && !isReturning)
        {
            StartSwing();
        }

        if (isSwinging)
        {
            SwingBat();
        }

        if (isReturning)
        {
            ReturnToOriginalPosition();
        }
    }

    private void StartSwing()
    {
        isSwinging = true;
    }

    private void SwingBat()
    {
        // Calculate the rotation angle for this frame
        float swingAngle = swingSpeed * Time.deltaTime;

        // Add the swing angle to the current swing angle
        currentSwingAngle += swingAngle;

        // Clamp the current swing angle to the maximum swing angle
        currentSwingAngle = Mathf.Clamp(currentSwingAngle, 0f, maxSwingAngle);

        // Calculate the new position on the circular path
        Vector3 newPosition = originalPosition + Quaternion.Euler(0f, currentSwingAngle, 0f) * (Vector3.forward * swingRadius);

        // Calculate the new rotation based on the swing angle
        Quaternion newRotation = originalRotation * Quaternion.Euler(0f, currentSwingAngle, 0f);

        // Apply the new position and rotation to the bat relative to the player
        transform.localPosition = newPosition;
        transform.localRotation = newRotation;

        // If we reached the maximum swing angle, stop swinging and start returning
        if (currentSwingAngle >= maxSwingAngle)
        {
            currentSwingAngle = maxSwingAngle;
            isSwinging = false;
            isReturning = true;
        }
    }

    private void ReturnToOriginalPosition()
    {
        // Calculate the rotation angle for returning to the original position
        float returnAngle = returnSpeed * Time.deltaTime;

        // Subtract the return angle from the current swing angle
        currentSwingAngle -= returnAngle;

        // Ensure that the angle does not go below zero
        if (currentSwingAngle <= 0f)
        {
            currentSwingAngle = 0f;
            isReturning = false;
        }

        // Calculate the new position on the circular path for returning
        Vector3 returnPosition = originalPosition + Quaternion.Euler(0f, currentSwingAngle, 0f) * (Vector3.forward * swingRadius);

        // Calculate the new rotation based on the return angle
        Quaternion returnRotation = originalRotation * Quaternion.Euler(0f, currentSwingAngle, 0f);

        // Apply the new position and rotation to the bat relative to the player for returning
        transform.localPosition = returnPosition;
        transform.localRotation = returnRotation;
    }
}
