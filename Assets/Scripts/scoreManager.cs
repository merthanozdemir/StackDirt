using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static scoreManager instance;
    private int score = 0;
    private int highScore = 0;
    public Text scoreText;
    public Text highscoreText;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "HighScore: " + highScore.ToString();
    }

   public void addScore()
    {

        score++;
        scoreText.text = "Score: " + score.ToString();
        if (highScore < score) {
            PlayerPrefs.SetInt("highScore", score);
            


        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
