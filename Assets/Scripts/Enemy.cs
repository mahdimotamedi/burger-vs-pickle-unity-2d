using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;
    private CameraShake cameraShake;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Burger")
        {
            if (cameraShake != null)
            {
                cameraShake.Shake();
            }

            gameManager.GameOver();
        }
    }
}
