    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class ScoreManager : MonoBehaviour {
      public Text scoreText;
      public Text BestScoreText;
      private float score;
      public float scoreCount; 
      public float pointsPerSecond; 
    
      void start()
      {
        BestScoreText.text = "0";
        scoreText.text = "0";
        scoreCount = 0;
        score = 0;
      }
    
      void Update () {
        scoreCount += pointsPerSecond * Time.deltaTime;
        score = 100;
      }
    
      void FixedUpdate() {
        score = score + scoreCount; 
        scoreText.text = "Your Score : " + Mathf.Round (score);
        BestScoreText.text = "Best Score : " + ((int)PlayerPrefs.GetFloat("BestScore"));
    
        if (score > PlayerPrefs.GetFloat ("BestScore")) {
          PlayerPrefs.SetFloat ("BestScore", score);
        }
      }
    }
