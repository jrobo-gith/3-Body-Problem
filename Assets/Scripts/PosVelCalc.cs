using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosVelCalc : MonoBehaviour
{
    public GameObject body;
    public Manager manager;

    public List<GameObject> spawnBodies(int numBodies, List<Vector2>initPositions)
    {
        List<GameObject> bodies = new List<GameObject>();

        for (int i=0; i < numBodies; i++)
        {
            GameObject B = Instantiate(body, initPositions[i], Quaternion.identity);
            B.GetComponent<SpriteRenderer>().color = Color.blue;

            bodies.Add(B);
        }

        Debug.Log("Instantiation found! Instantiated " + numBodies + " bodies, here is a list of them if you dont believe me:");
        Debug.Log(bodies);

        return bodies;
    }

    //public List<Vector2> calculateAcc(List<Vector2> positions)
    //{
    //    List<Vector2> accelerations = new List<Vector2>();

    //    float mass = manager.mass;
    //    // Calculates updated velocities

    //    Vector2 p1 = positions[0];
    //    Vector2 p2 = positions[1];
    //    Vector2 p3 = positions[2];

    //    float a1_denominator1 = Mathf.Pow(Mathf.Sqrt(Mathf.Pow((p1.x - p2.x), 2) + Mathf.Pow((p1.y - p2.y), 2)), 3);
    //    float a1_denominator2 = Mathf.Pow(Mathf.Sqrt(Mathf.Pow((p1.x - p3.x), 2) + Mathf.Pow((p1.y - p3.y), 2)), 3);

    //    float a2_denominator1 = Mathf.Pow(Mathf.Sqrt(Mathf.Pow((p2.x - p3.x), 2) + Mathf.Pow((p2.y - p3.y), 2)), 3);
    //    float a2_denominator2 = Mathf.Pow(Mathf.Sqrt(Mathf.Pow((p2.x - p1.x), 2) + Mathf.Pow((p2.y - p1.y), 2)), 3);

    //    float a3_denominator1 = Mathf.Pow(Mathf.Sqrt(Mathf.Pow((p3.x - p1.x), 2) + Mathf.Pow((p3.y - p1.y), 2)), 3);
    //    float a3_denominator2 = Mathf.Pow(Mathf.Sqrt(Mathf.Pow((p3.x - p2.x), 2) + Mathf.Pow((p3.y - p2.y), 2)), 3);

    //    Vector2 a1 = -G * mass * ((p1 - p2) / a1_denominator1) - G * mass * ((p1 - p3) / a1_denominator2);
    //    Vector2 a2 = -G * mass * ((p2 - p3) / a2_denominator1) - G * mass * ((p2 - p1) / a2_denominator2);
    //    Vector2 a3 = -G * mass * ((p3 - p1) / a3_denominator1) - G * mass * ((p3 - p2) / a3_denominator2);

    //    accelerations.Add(a1);
    //    accelerations.Add(a2);
    //    accelerations.Add(a3);

    //    Debug.Log(-G * mass * ((p1 - p2) / a1_denominator1));
    //    Debug.Log(a1);

    //    //for (int i = 0; i < 3; i++)
    //    //{
    //    //Vector3 dir3 = Random.onUnitSphere;
    //    //velocities.Add(dir3);

    //    //}
    //    //Debug.Log(accelerations[1]);

    //    //List<Vector2> accelerations = new List<Vector2> { Vector2.zero, Vector2.zero, Vector2.zero };

    //    //float mass = manager.mass;
    //    //float G = 1.0f; // Make sure G is nonzero

    //    //float epsilon = 1e-6f; // Prevent division by zero

    //    //for (int i = 0; i < 3; i++)
    //    //{
    //    //    for (int j = 0; j < 3; j++)
    //    //    {
    //    //        if (i != j)
    //    //        {
    //    //            Vector2 diff = positions[j] - positions[i];
    //    //            float distanceSq = diff.sqrMagnitude + epsilon;
    //    //            float distanceCubed = Mathf.Pow(distanceSq, 3.0f);
    //    //            Debug.Log(diff/distanceCubed);

    //    //            accelerations[i] += G * mass * diff / distanceCubed;
    //    //        }
    //    //    }
    //    //}
    //    //Debug.Log(positions[0]);

    //    return accelerations;
    //}

}
