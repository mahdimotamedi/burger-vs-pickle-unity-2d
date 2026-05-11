using UnityEngine;

public class CollectEffect : MonoBehaviour
{
    public float lifeTime = 0.35f;
    public float growSpeed = 3f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        transform.localScale += Vector3.one * growSpeed * Time.deltaTime;

        Color color = GetComponent<SpriteRenderer>().color;
        color.a = 1f - (timer / lifeTime);
        GetComponent<SpriteRenderer>().color = color;

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
