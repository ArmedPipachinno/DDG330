using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementBod : MonoBehaviour
{
    [SerializeField] Rigidbody RigidPlay;
    [SerializeField] float _WalkSpeed = 1.0f;
    [SerializeField] float _RunSpeed = 2.0f;
    //private float _Accel = .75f;

    bool Run =false;

    private void Awake()
    {
        RigidPlay = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    void Update()
    {
        bool Run = Input.GetKey(KeyCode.LeftShift);
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        float TargetSpeed = Run ? _RunSpeed : _WalkSpeed;

        // Calculate the movement direction
        Vector3 moveDirection = new Vector3(HorizontalInput, 0f, VerticalInput).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run = true;
        }

        // Calculate the velocity based on the direction and speed
        Vector3 velocity = moveDirection * TargetSpeed;

        // Move the object based on the calculated velocity
        Vector3 newPosition = RigidPlay.transform.position + velocity * Time.deltaTime;
        RigidPlay.MovePosition(newPosition);
    }
}
