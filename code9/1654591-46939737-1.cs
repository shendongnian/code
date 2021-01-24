    void Start()
    {
        rewardBasedVideo = null;
        GetComponent<SpriteRenderer> ().enabled = false;
        //highscore = PlayerPrefs.GetInt ("highscore");
        adUnitId = "ca-app-pub-2**97684242*****/15*08*****";
        rewardBasedVideo = RewardBasedVideoAd.Instance;
        AdRequest request = new AdRequest.Builder().Build();
        rewardBasedVideo.LoadAd(request, adUnitId);
        // Add a listener only when the script is loaded
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
    }
    private void showAdd(RewardBasedVideoAd rewardBasedVideo)
    {
        if (rewardBasedVideo.IsLoaded())
        {
            if (GameOverScript.GameOver) 
            {
                rewardBasedVideo.Show ();
            }
        }
    }
