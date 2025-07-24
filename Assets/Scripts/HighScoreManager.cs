using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }
}
