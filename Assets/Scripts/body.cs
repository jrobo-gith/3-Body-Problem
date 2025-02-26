//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class body : MonoBehaviour
//{
//    public Manager manager;
//    public float mass;
//    public Vector3 initialVelocity;
//    Vector3 currentVelocity;

//    void Start()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            initialVelocity = Random.onUnitSphere;

//        }
//        currentVelocity = initialVelocity;
//    }

//    public void updateVelocity(List<GameObject> bodies)
//    {
//        foreach (GameObject otherBody in bodies)
//        {
//            if (otherBody != this)
//            {
//                Vector3 diff = otherBody.transform.position - transform.position;
//                float distance = diff.magnitude+1e-6f;
//                Vector3 forceDir = diff / distance;
//                Vector3 force = forceDir * (manager.G * mass / (distance*distance));
//                Vector3 acceleration = force / mass;

//                currentVelocity += acceleration * Time.deltaTime;

//                Debug.Log(diff);
//                Debug.Log(distance);
//                Debug.Log(forceDir);
//                Debug.Log(force);
//                Debug.Log(acceleration);
//                //Debug.Log(currentVelocity);
//            }
//        }
//    }

//    public void updatePosition()
//    {
//        transform.position += currentVelocity * Time.deltaTime;
//    }
//}
