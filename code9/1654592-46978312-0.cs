        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;
        using GoogleMobileAds.Api;
        using System.Threading;
        
        public class RewardAd : MonoBehaviour {
        
        	public bool called;
        	public int highscore;
        	public int score;
        	public static GameObject drawscore_obj;
        	public RewardBasedVideoAd rewardBasedVideo = null;
        	public string adUnitId;
        
        	void Start()
        	{
        		called = false;
        		rewardBasedVideo = null;
        		GetComponent<SpriteRenderer> ().enabled = false;
        		//highscore = PlayerPrefs.GetInt ("highscore");
        		adUnitId = "ca-app-pub-2879768424205988/1590886374";
        		rewardBasedVideo = RewardBasedVideoAd.Instance;
        		AdRequest request = new AdRequest.Builder().Build();
        		rewardBasedVideo.LoadAd(request, adUnitId);
        		rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        	}
        	void Update()
        	{
        		if (GameOverScript.GameOver) 
        		{
        			GetComponent<SpriteRenderer> ().enabled = true;
        		}
        	}
        
        	void OnMouseDown()
        	{
        		showAdd(rewardBasedVideo);
        	}
        
        	private void showAdd(RewardBasedVideoAd rewardBasedVideo)
        	{
        		if (rewardBasedVideo.IsLoaded())
        		{
        			if (GameOverScript.GameOver) 
        			{
        				rewardBasedVideo.Show ();
        				called = true;
        			}
        		}
        	}
        
        	public void HandleRewardBasedVideoRewarded(object sender, Reward args)
        	{	
        		if (called == true) 
        		{
        			called = false;
        			highscore = PlayerPrefs.GetInt ("highscore");
        
        			if ((Controll.points + 10) > highscore) {
        				Controll.points += 10;
        				if (Controll.points > highscore) {
        					PlayerPrefs.SetInt ("highscore", highscore);
        				}
        			}
        		}
        	 }
          }
