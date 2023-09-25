using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementBod : MonoBehaviour
{
    [SerializeField] Camera Cam_Val;
    [SerializeField] Rigidbody RigidPlay;
    [SerializeField] private float _WalkSpeed = 1.0f;
    [SerializeField] private float _RunSpeed = 2.0f;
    //private float _Accel = .75f;
    [SerializeField] private float RotationSpeed = 15.0f;

    private Vector3 mouseRotation;

    private void Awake()
    {
        RigidPlay = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool Run = Input.GetKey(KeyCode.LeftShift);
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        float TargetSpeed = Run ? _RunSpeed : _WalkSpeed;

        Vector3 moveDirection = new Vector3(HorizontalInput, 0f, VerticalInput).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run = true;
        }

        Vector3 velocity = moveDirection * TargetSpeed;

        Vector3 newPosition = RigidPlay.transform.position + velocity * Time.deltaTime;
        RigidPlay.MovePosition(newPosition);
    }

    //float cameraHorizontalAngle = _CurtHoriAngle;
    ////Rotate the player character towards the camera direction
    //Quaternion TargetRotation = Quaternion.Euler(0f, 0f /*cameraHorizontalAngle*/, 0f);
    //transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * RotationSpeed);
}

