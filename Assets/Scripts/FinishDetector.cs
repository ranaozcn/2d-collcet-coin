using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                int score = ScoreManager.currentScore;
                player.SaveHighScore();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
