using UnityEngine;

public class lineScript : MonoBehaviour
{
    SpriteRenderer spriteRend;
    private float delay = 10.0f;
    private float timer = 0f;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float alpha = Mathf.Lerp(1f, 0f, timer / delay);
        spriteRend.color = new Color(spriteRend.color.r, spriteRend.color.g, spriteRend.color.b, alpha);
        if (timer > delay)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
