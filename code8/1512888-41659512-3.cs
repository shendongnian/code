    //state
    public enum GameMode { Normal, Endless, Campaign, Idle, Count }
    private GameMode gameMode;
    //state machine array
	private delegate void UpdateDelegate();
	private UpdateDelegate[] UpdateDelegates;
	void Awake()
	{
		//setup all UpdateDelegates here to avoid runtime memory allocation
		UpdateDelegates = new UpdateDelegate[(int)GameMode.Count];
		//and then each UpdateDelegate
		UpdateDelegates[(int)GameMode.Normal] = UpdateNormalState;
		UpdateDelegates[(int)GameMode.Endless] = UpdateEndlessState;
		UpdateDelegates[(int)GameMode.Campaign] = UpdateCampaignState;
		UpdateDelegates[(int)GameMode.Idle] = UpdateIdleState
        gameMode = GameMode.Idle;
	}
  
    void Update()
    {
         //call the update method of current state
         if(UpdateDelegates[(int)gameMode]!=null)
             UpdateDelegates[(int)gameMode]();
    }
