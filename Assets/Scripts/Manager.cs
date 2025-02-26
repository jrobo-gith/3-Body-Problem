using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject body;

    public List<Vector2> initialPos;
    public List<Vector2> initialVel;
    public List<Vector2> masses = new List<Vector2>();
    private List<GameObject> bodies;

    public float dt = 0.1f;

    private List<Vector2> velocity =    new List<Vector2>();
    private List<Vector2> position =    new List<Vector2>();
    private List<Vector2> forces =       new List<Vector2>();

    public int numBodies = 3;

    private void Start()
    {
        bodies = spawnBodies(numBodies, initialPos);
        velocity = initialVel;
        position = initialPos;

        forces = gravity(bodies);
    }

    private void Update()
    {
        // Step 1:
        for (int i = 0; i < forces.Count; i++)
        {
            Vector2 force = forces[i];
            velocity[i] += new Vector2(0.5f, 0.5f) * new Vector2(Time.deltaTime*dt, Time.deltaTime*dt) * force/masses[i];
        }

        // Step 2:
        for (int i = 0; i < forces.Count; i++)
        {
            Vector2 vel = velocity[i];
            position[i] += vel * Time.deltaTime*dt;
        }

        // Step 3:
        forces = gravity(bodies);
        for (int i = 0; i < forces.Count; i++)
        {
            Vector2 force = forces[i];
            velocity[i] += force / masses[i] * (Time.deltaTime*dt / 2);
        }

        for (int i = 0; i < forces.Count; i++)
        {
            GameObject body = bodies[i];

            body.transform.position = position[i];
        }


    }

    private List<GameObject> spawnBodies(int numBodies, List<Vector2> initPositions)
    {
        List<GameObject> bodies = new List<GameObject>();

        for (int i = 0; i < numBodies; i++)
        {
            GameObject B = Instantiate(body, initPositions[i], Quaternion.identity);
            B.GetComponent<SpriteRenderer>().color = Color.blue;
            B.transform.localScale = new Vector3(0.3f, 0.3f, 0);

            bodies.Add(B);
        }

        Debug.Log("Instantiation found! Instantiated " + numBodies + " bodies, here is a list of them if you dont believe me:");
        Debug.Log(bodies);

        return bodies;
    }

    private List<Vector2> gravity(List<GameObject> bodies)
    {
        List<Vector2> f = new List<Vector2>();

        for (int i = 0; i < bodies.Count; i++)
        {
            Vector2 ri = bodies[i].transform.position;
            float ri_mass = masses[i][0];
            List<float> forces = new List<float>();
            List<Vector2> directions = new List<Vector2>();

            for (int j = 0; j < bodies.Count; j++)
            {
                Vector2 rj = bodies[j].transform.position;

                if (i != j)
                {
                    float rj_mass = masses[j][0];
                    float distance = Vector2.Distance(rj, ri);
                    forces.Add(calcForce(distance, ri_mass, rj_mass));
                    directions.Add(calcDirection(ri, rj));
                }
            }
            Vector2 resultantForce = Vector2.zero;
            for (int k = 0; k < forces.Count; k++)
            {
                resultantForce += forces[k] * directions[k];
            }
            f.Add(resultantForce);
        }

        return f;
    }

    private float calcForce(float distance, float m1, float m2)
    {
        return (m1 * m2) / (Mathf.Pow(distance, 2));
    }
    private Vector2 calcDirection(Vector2 ri, Vector2 rj)
    {
        return (rj - ri) / Vector2.Distance(ri, rj);
    }

}
