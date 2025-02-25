using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float G = 1.0f;
    public PosVelCalc PVC;
    public int numBodies = 3;

    public List<Vector2> initialPos;

    private List<GameObject> bodies;

    private void Start()
    {
        bodies = PVC.spawnBodies(numBodies, initialPos);
        Debug.Log("AYO");
    }

    private void FixedUpdate()
    {
        foreach (GameObject bod in bodies)
        {
            body BS = bod.GetComponent<body>();
            BS.updateVelocity(bodies);
        }

        foreach (GameObject bod in bodies)
        {
            body BS = bod.GetComponent<body>();
            BS.updatePosition();
        }
    }

    //public List<Vector2> initialPositions;
    //public List<Vector2> initialVelocities;
    //public int numBodies = 3;
    //public float G = 1.0f;

    //private Dictionary<int, GameObject> bodies = new Dictionary<int, GameObject>();

    //void Start()
    //{
    //    bodies = PVC.spawnBodies(numBodies, initialPositions);
    //    updatePositions(bodies, initialVelocities);

    //}

    //void FixedUpdate()
    //{
    //    //List<Vector2> positions = getPositions(bodies);
    //    //List<Vector2> velocities = PVC.calculateAcc(positions);
    //    //updatePositions(bodies, velocities);
    //}

    //private List<Vector2> getPositions(Dictionary<int, GameObject> bodys)
    //{
    //    List<Vector2> positions = new List<Vector2>();

    //    foreach (KeyValuePair<int, GameObject> body in bodys)
    //    {
    //        Vector2 pos = new Vector2(body.Value.transform.position.x, body.Value.transform.position.y);
    //        positions.Add(pos);
    //    }

    //    return positions;
    //}

    //private void updatePositions(Dictionary<int, GameObject> bodys, List<Vector2> vels)
    //{
    //    foreach (KeyValuePair<int, GameObject> body in bodys)
    //    {
    //        body.Value.transform.position += new Vector3(vels[body.Key].x, vels[body.Key].y, 0) * Time.deltaTime;
    //    }
    //}
}
