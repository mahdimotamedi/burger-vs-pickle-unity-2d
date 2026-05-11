using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public bool gameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public BurgerController burger;
    public MovingObject pickle;

    private bool speedDoubledAt10 = false;
    private bool speedDoubledAt20 = false;
    private bool speedDoubledAt30 = false;

    private void Start()
    {
        UpdateScore();
        gameOverText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }

        UpdatePickleSpeed();
    }

    private void UpdatePickleSpeed()
    {
        if (gameOver || burger == null || pickle == null)
        {
            return;
        }

        float burgerScale = burger.transform.localScale.x;

        if (burgerScale > 12 && speedDoubledAt30 == false)
        {
            pickle.speed *= 1.1f;
            speedDoubledAt30 = true;
        }
        else if (burgerScale > 8 && speedDoubledAt20 == false)
        {
            pickle.speed *= 1.1f;
            speedDoubledAt20 = true;
        }
        else if (burgerScale > 3 && speedDoubledAt10 == false)
        {
            pickle.speed *= 1.2f;
            speedDoubledAt10 = true;
        }
    }

    public void AddScore(int amount)
    {
        if (gameOver)
        {
            return;
        }

        score += amount;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.gameObject.SetActive(true);
        burger.StopBurger();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
