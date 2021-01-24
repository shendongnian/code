    private void showAdd(RewardBasedVideoAd rewardBasedVideo) {
            if (rewardBasedVideo.IsLoaded())
            {
                //Subscribe to Ad event
                rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
                rewardBasedVideo.Show();
            }else {
                AdRequest request = new AdRequest.Builder().Build();
                rewardBasedVideo.LoadAd(request, adUnitId);
            }
    }
