    public void DoTheAction(Action<bool> onComplete = null)
        {
        	if (rewardBasedVideo.IsLoaded())
        	{
        		rewardBasedVideo.Show();
        		rewardBasedVideo.OnAdRewarded -= HandleOnAdRewarded;
        		rewardBasedVideo.OnAdRewarded += HandleOnAdRewarded;	
        	}
        }
        
        private void HandleOnAdRewarded(object sender, EventArgs e)
        {
        	onComplete(true);
        }
