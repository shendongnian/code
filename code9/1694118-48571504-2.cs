	public MainViewModel() {
		_client = new HttpEndpoint(Url, User, Pass);
		TriggerDoorCommand = new Command(async () => await ExecuteTriggerDoorCommand());
		//Subscribe to event
		GetData += GetDataHandler;
		//Raise event
		GetData(this, EventArgs.Empty);
	}
	private event EventHandler GetData = delegate { }; 
	private async void GetDataHandler(object sender, EventArgs args) {
		_currentDoorFunc = await GetCurrentDoorFunction();
	}
	private async Task<GPIOFunctions> GetCurrentDoorFunction() {
		return await _client.GetGPIOFunction(DOOR_TOGGLE_PIN);
	}
