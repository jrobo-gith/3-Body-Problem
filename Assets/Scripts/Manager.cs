using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public PosVelCalc PVC;
    public List<Vector2> initialPositions;
    public List<Vector3> initialVelocities;
    public int numBodies = 3;

    private Dictionary<int, GameObject> bodies = new Dictionary<int, GameObject>();

    void Start()
    {
        bodies = PVC.spawnBodies(numBodies, initialPositions);
        updatePositions(bodies, initialVelocities);
   
    }

    void FixedUpdate()
    {
        List<Vector2> positions = getPositions(bodies);
        List<Vector3> velocities = PVC.calculateVel(positions);
        updatePositions(bodies, velocities);
    }

    private List<Vector2> getPositions(Dictionary<int, GameObject> bodys)
    {
        List<Vector2> positions = new List<Vector2>();

        foreach (KeyValuePair<int, GameObject> body in bodys)
        {
            Vector2 pos = new Vector2(body.Value.transform.position.x, body.Value.transform.position.y);
            positions.Add(pos);
        }

        return positions;
    }

    private void updatePositions(Dictionary<int, GameObject> bodys, List<Vector3> vels)
    {
        foreach (KeyValuePair<int, GameObject> body in bodys)
        {
            body.Value.transform.position += vels[body.Key] * Time.deltaTime;
        }
    }
}
