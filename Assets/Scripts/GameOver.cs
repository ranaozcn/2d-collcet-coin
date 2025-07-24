using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    void Start()
    {
        int score = ScoreManager.currentScore;
        scoreText.text = "Score: " + score;
        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TryAgain()
    {
        ScoreManager.currentScore = 0; 
        ScoreManager.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}