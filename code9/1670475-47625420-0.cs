	if (_googleApiClient == null) //  _googleApiClient is a class level variable
	{
		_googleApiClient = new GoogleApiClient.Builder(this)
		  .AddApi(DriveClass.API)
		  .AddScope(DriveClass.ScopeFile)
		  .AddConnectionCallbacks(this)
		  .AddOnConnectionFailedListener(onConnectionFailed)
		  .Build();
	}
	if (!_googleApiClient.IsConnected)
		_googleApiClient.Connect();
