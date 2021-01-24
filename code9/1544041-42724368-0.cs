	private ObservableCollection<ActionObject> myActions;
	public ObservableCollection<ActionObject> Actions
	{
		get 
        {
             if (myActions == null) 
                 myActions = new ObservableCollection<ActionObject>();
             return myActions; 
        }
	}
	private ObservableCollection<string> myCommands;
	public ObservableCollection<string> Commands
	{
		get 
        {
            if (myCommands == null) 
                myCommands = new ObservableCollection<string>();
            return myCommands; 
        }
	}
