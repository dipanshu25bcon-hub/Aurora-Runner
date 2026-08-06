using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private float score = 0f;
    private int highScore = 0;

    void Start()
    {
        // Load High Score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score : " + highScore;
    }

    void Update()
    {
        score += Time.deltaTime * 10f;

        int currentScore = Mathf.FloorToInt(score);

        scoreText.text = "Score : " + currentScore;

        if (currentScore > highScore)
        {
            highScore = currentScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            highScoreText.text = "High Score : " + highScore;
        }
    }
}