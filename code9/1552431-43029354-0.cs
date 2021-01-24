	public TwitterCommunicator TwitterCommunicator => _twitterCommunicator ?? (_twitterCommunicator = new TwitterCommunicator());
	
	public void AnotherTwitterPanelMethod()
	{
		TwitterCommunicator.LoadTweets();
	}
