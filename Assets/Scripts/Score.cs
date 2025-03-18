using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public float timer = 0f;
    public float timerRate = 1f;
    public Text scoreDisplay;
    public int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore",0);

    }
    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HighScore", highscore);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime*timerRate;
        if (timer >= 1)
        {
            score++;
            scoreDisplay.text = "Score:" + score.ToString();
            timer = 0f;
            if(score >= highscore)
            {
                highscore = score;
            }
        }
    }
}
