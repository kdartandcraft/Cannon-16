using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

// https://www.youtube.com/watch?v=0zrZZN-QaDk
// C# Survival Guie - Singleton
public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("ScoreManager is NULL");
            }
            return instance;
        }
    }

    public int score;
    public int highScore;
    //public int HighScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    //public TMP_TextMeshProUGUI gameOverScoreText;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = "High Score: " + highScore.ToString();
            //nameText.text = PlayerPrefs.GetString("NameText");
        }
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void AddScore()
    {
        score++;

        scoreText.text = "Score: " + score.ToString();
        //gameOverScoreText.text = "High Score: " + score.ToString();

        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
        }
        
        highScoreText.text = "High Score: " + highScore.ToString();
        scoreText.text = "Score: " + score.ToString();
        //PlayerPrefs.SetInt("HighScore", highScore);
        //PlayerPrefs.SetInt("Score", score);
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");

        score = 0;
        scoreText.text = "Score: " + score.ToString();

        //gameOverScoreText.text = score.ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");

        highScore = 0;
        highScoreText.text = "High Score: " + highScore.ToString();
    }


}
