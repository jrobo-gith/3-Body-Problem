using UnityEngine;

public class bodyScript : MonoBehaviour
{
    public Vector2 prevPos;
    public Vector2 currPos;
    public bool distElapsed;
    public GameObject Line;

    private float lineSize = 0.05f;

    SpriteRenderer spriteRend;

    private void Start()
    {
        prevPos = transform.position;
    }

    void Update()
    {
        (currPos, distElapsed) = checkDistance(prevPos, transform.position);

        if (distElapsed)
        {
            prevPos = currPos;
            distElapsed = false;
            spawnLine();
        }

    }

    private (Vector2, bool) checkDistance(Vector2 prevPos, Vector2 currPos)
    {
        float radius = transform.localScale.x;
        bool distanceElapsed = false;

        float distance = Vector2.Distance(prevPos, currPos);

        if (distance > lineSize)
        {
            distanceElapsed = true;
        }

        return (currPos, distanceElapsed);
    }

    private void spawnLine()
    {
        GameObject line = Instantiate(Line, transform.position, Quaternion.identity);

        spriteRend = GetComponent<SpriteRenderer>();
        line.GetComponent<SpriteRenderer>().color = spriteRend.color;
        line.transform.localScale = new Vector2(lineSize, lineSize);
    }
}
