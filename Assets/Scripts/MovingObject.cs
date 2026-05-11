using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float speed = 4f;
    public float resetX = 6f;
    public float destroyX = -6f;

    public float minY = -2f;
    public float maxY = -1.2f;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void Update()
    {
        if (gameManager.gameOver)
        {
            return;
        }

        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        float randomY = Random.Range(minY, maxY);
        transform.position = new Vector3(resetX, randomY, transform.position.z);
    }
}
