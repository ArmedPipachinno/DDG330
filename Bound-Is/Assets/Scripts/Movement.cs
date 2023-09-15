using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody RigidPlay;
    private Animator _Animate;
    private float _Speed = 0f;
    private float _Dir = 0f;
    private float _MaxWalk = 1.0f;
    private float _MaxSpeed = 2.0f;
    private float _Accel = .75f;

    private void Awake()
    {
        TryGetComponent<Rigidbody>(out RigidPlay);
    }

    void Update()
    {
        bool Run = Input.GetKey(KeyCode.LeftShift);
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        float TargetSpeed = Run ? _MaxSpeed : _MaxWalk;

        _Speed = Mathf.MoveTowards(_Speed, TargetSpeed * VerticalInput, _Accel * Time.deltaTime);//_Speed = Mathf.MoveTowards(_Speed, VerticalInput, _Decel * Time.deltaTime);
        _Dir = Mathf.MoveTowards(_Dir, TargetSpeed * HorizontalInput, _Accel * Time.deltaTime); //_Dir = Mathf.MoveTowards(_Dir, HorizontalInput, _Decel * Time.deltaTime);

        //RigidPlay = new Vector3(0,0,0);
    }

}
/*
// Start is called before the first frame update
void Start()
{
    //GetComponent<MouseCursor>();
}

        /*
float HorizontalInput = Input.GetAxis("Mouse X");
float VerticalInput = Input.GetAxis("Mouse Y");
transform.Rotate(0f, HorizontalInput, 0f, Space.World);
transform.Rotate(-VerticalInput, 0f, 0f, Space.Self);
if (Input.GetKey(KeyCode.W))
{
    transform.position += Vector3.forward * speed * Time.deltaTime;//new Vector3(0,0, speed * Time.deltaTime);
}
else if(Input.GetKey(KeyCode.S))
{ 
    transform.position += Vector3.back * speed * Time.deltaTime;//new Vector3(0, 0, speed * Time.deltaTime);
}
if (Input.GetKey(KeyCode.A)) 
{
    transform.position += Vector3.left * speed * Time.deltaTime;
}
else if (Input.GetKey(KeyCode.D)) 
{
    transform.position += Vector3.right * speed * Time.deltaTime;
}

if (Input.GetMouseButton(0))
{
    transform.position += Vector3.up * speed * Time.deltaTime;//new Vector3(0, speed * Time.deltaTime, 0);
}
else if (Input.GetMouseButton(1)) 
{
    transform.position += Vector3.down * speed * Time.deltaTime;
}


//transform.TransformDirection;
//Vector3.Normalize(transform.position);

reference->watch?v=7kGCrq1cJew
*/

/*
 *  //[field:SerializeField] float Speed = 0.05f;
    //[field: SerializeField] float ElevationSpeed = 5.0f;
    //[field: SerializeField] float RotateSpeed = 0.5f;

    //void Update()
    //{
    //    CamRotate();

    //    MoveCamRelate();

    //    MouseElevate();

    //}   

    //void CamRotate()
    //{
    //    float HorizontalInput = Input.GetAxis("Mouse X");
    //    float VerticalInput = Input.GetAxis("Mouse Y");
    //    transform.Rotate(0f, HorizontalInput * RotateSpeed, 0f, Space.World);
    //    transform.Rotate(-VerticalInput * RotateSpeed, 0f, 0f, Space.Self);
    //}

    //void MoveCamRelate()
    //{
    //    float PlayerHorizontal = Input.GetAxis("Horizontal");
    //    float PlayerVertical = Input.GetAxis("Vertical");

    //    Vector3 forward = Camera.main.transform.forward;
    //    Vector3 Right = Camera.main.transform.right;

    //    Vector3 ForwardRelativeVerticalInput = PlayerVertical * forward * Speed;
    //    Vector3 RightRelativeHorizontalInput = PlayerHorizontal * Right * Speed;

    //    Vector3 CameraRelativeMovement = ForwardRelativeVerticalInput + RightRelativeHorizontalInput;
    //    this.transform.Translate(CameraRelativeMovement, Space.World);
    //}

    //void MouseElevate()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        transform.position += Vector3.up * ElevationSpeed * Time.deltaTime;//new Vector3(0, speed * Time.deltaTime, 0);
    //    }
    //    else if (Input.GetMouseButton(1))
    //    {
    //        transform.position += Vector3.down * ElevationSpeed * Time.deltaTime;
    //    }
    //}
 */