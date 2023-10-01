using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class BounceController : MonoBehaviour
{
    public float bounceForce = 10.0f; // Adjust this value to control the bounce force

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with something
        if (collision.gameObject.CompareTag("BounceSurface") || collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Player") ) // BounceSurface
        {
            // Calculate the bounce direction based on the collision normal
            Vector3 bounceDirection = Vector3.Reflect(transform.forward, collision.contacts[0].normal);

            // Apply the bounce force with the calculated direction
            GetComponent<Rigidbody>().AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
