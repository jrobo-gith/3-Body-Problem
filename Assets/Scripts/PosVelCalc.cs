using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosVelCalc : MonoBehaviour
{
    public GameObject body;

    public Dictionary<int, GameObject> spawnBodies(int numBodies, List<Vector2>initPositions)
    {
        Dictionary<int, GameObject> bodies = new Dictionary<int, GameObject>();

        for (int i=0; i < numBodies; i++)
        {
            GameObject B = Instantiate(body, initPositions[i], Quaternion.identity);
            B.GetComponent<SpriteRenderer>().color = Color.blue;


            bodies.Add(i, B);
        }

        Debug.Log("Instantiation found! Instantiated " + numBodies + " bodies, here is a list of them if you dont believe me:");
        Debug.Log(bodies);

        return bodies;
    }

    public List<Vector3> calculateVel(List<Vector2> positions)
    {
        List<Vector3> velocities = new List<Vector3>();

        // Calculates updated velocities
        // Currently generates random velocities
        for (int v=0; v < 3; v++)
        {
            Vector3 dir3 = Random.onUnitSphere;
            velocities.Add(dir3);
        }


        return velocities;
    }
}
