       using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class HUDScript : MonoBehaviour {
    
    	float playerScore = 0;
    	public Text scoreText;
    
    
    	void Start () {
    	}
    
    	void Update () {
    		playerScore += Time.fixedDeltaTime;
    		scoreText.text = "Score: " + Mathf.Round((playerScore * 100)).ToString();
    
    	}
    
    
    	public void IncreaseScore(int amount){
    		playerScore += amount;
    	}
    
    	void OnDisable() {
    		PlayerPrefs.SetFloat ("Score", Mathf.Round((playerScore * 100)));
    
    	}
    
    }
    
        using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class GameOverScript : MonoBehaviour {
    
    	HUDScript hud;
    	float score = 0;
    	float highScore;
    	public Text scoreText;
    	public Text highScoreText;
    
    
    	// Use this for initialization
    	void Start () {
    		score = PlayerPrefs.GetFloat ("Score");
    		highScore = PlayerPrefs.GetFloat ("HighScore", 0);
    
    		scoreText.text = "Score: " + score.ToString ();
    		if (score > highScore) {
    		highScoreText.text = "High Score: " + score.ToString ();
    			PlayerPrefs.SetFloat("HighScore", score);
    		} else {
    			highScoreText.text = "High Score: " + highScore.ToString();
    		}
    
    	}
    
    }
