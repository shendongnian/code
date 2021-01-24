    private void showAdd(RewardBasedVideoAd rewardBasedVideo)
    {
        if (rewardBasedVideo.IsLoaded())
        {
            if (GameOverScript.GameOver) 
            {
                rewardBasedVideo.Show ();
                rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            }
        }
    }
