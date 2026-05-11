using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 1;

    private GameManager gameManager;
    private MovingObject movingObject;
    private CollectEffectSpawner effectSpawner;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        movingObject = GetComponent<MovingObject>();
        effectSpawner = FindObjectOfType<CollectEffectSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Burger")
        {
            gameManager.AddScore(scoreValue);
            // other.transform.localScale += new Vector3(0.1f, 0.1f, 0f);

            BurgerController burgerController = other.GetComponent<BurgerController>();
            burgerController.jumpForce += 0.1f;
            burgerController.holdJumpForce += 0.1f;

            if (gameObject.name.Contains("Cheese"))
            {
                Transform cheese = other.gameObject.transform.Find("Cheese");

                if (cheese != null)
                {
                    cheese.gameObject.SetActive(true);
                }
            }
            else if (gameObject.name.Contains("Ketchup"))
            {
                Transform ketchup = other.gameObject.transform.Find("Ketchup");

                if (ketchup != null)
                {
                    ketchup.gameObject.SetActive(true);
                }

                if (effectSpawner != null)
                {
                    effectSpawner.SpawnEffect(transform.position);
                }
            }
            else if (gameObject.name.Contains("Veg"))
            {
                Transform veg = other.gameObject.transform.Find("Veg");

                if (veg != null)
                {
                    veg.gameObject.SetActive(true);
                }
            }

            movingObject.ResetPosition();
        }
    }
}
