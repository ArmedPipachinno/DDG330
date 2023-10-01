using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnHandler : MonoBehaviour
{
    [SerializeField] GameObject BallsGrap; // Drag your object prefab here in the Unity Inspector
    [SerializeField] private Transform LaunchPoint;   // The point from which the object will be launched
    [SerializeField] float LaunchForce = 100f; // The force at which the object will be launched
    [SerializeField] int BallAvailable = 3;

    private GameObject SpawnedObject;
    private bool HoldingObject = false;

    private void Awake()
    {
        SpawnObject();
    }

    private void Update()
    {
        // Update the spawned object's position to match the launch point
        if (SpawnedObject != null && HoldingObject)
        {
            SpawnedObject.transform.position = LaunchPoint.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HoldingObject)
            {
                LaunchObject();
            }
            else if (!HoldingObject & BallAvailable != 0)
            {
                SpawnObject();
                BallAvailable--;
            }
        }
    }

    private void SpawnObject()
    {
        SpawnedObject = Instantiate(BallsGrap, LaunchPoint.position, Quaternion.identity);
        SpawnedObject.transform.parent = transform;
        HoldingObject = true;
    }

    private void LaunchObject()
    {
        if (SpawnedObject != null)
        {
            SpawnedObject.transform.parent = null;
            Rigidbody rb = SpawnedObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.AddForce(transform.forward * LaunchForce, ForceMode.Impulse);
            }
            SpawnedObject = null;
            HoldingObject = false;
        }
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BallSpawnHandler : MonoBehaviour
//{
//    [SerializeField] GameObject BallsGrap; // Drag your object prefab here in the Unity Inspector
//    [SerializeField] private Transform LaunchPoint;   // The point from which the object will be launched
//    [SerializeField] float LaunchForce = 10f; // The force at which the object will be launched
//    [SerializeField] int BallAvailable = 3;

//    private GameObject SpawnedObject;
//    private bool HoldingObject = false;

//    private void Awake()
//    {
//        SpawnObject();
//    }

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space)) // Left mouse click
//        {
//            if (HoldingObject)
//            {
//                LaunchObject();
//            }
//            else if (!HoldingObject & BallAvailable != 0)
//            {
//                SpawnObject();
//                BallAvailable --;
//            }
//        }
//    }

//    private void SpawnObject()
//    {
//        SpawnedObject = Instantiate(BallsGrap, LaunchPoint.position, Quaternion.identity);// Spawn the objectPrefab in front of the player character at the launchPoint
//        SpawnedObject.transform.parent = transform; // Make the player character the parent
//        HoldingObject = true;
//    }

//    private void LaunchObject()
//    {
//        if (SpawnedObject != null)
//        {
//            SpawnedObject.transform.parent = null;// Unparent the object
//            Rigidbody rb = SpawnedObject.GetComponent<Rigidbody>(); // Get the rigidbody of the spawned object and apply force forward
//            if (rb != null)
//            {
//                rb.isKinematic = false;
//                rb.AddForce(transform.forward * LaunchForce, ForceMode.Impulse);
//            }
//            // Reset variables
//            SpawnedObject = null;
//            HoldingObject = false;
//        }
//    }
//}
