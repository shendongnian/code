	FirebaseAuth.GetInstance(fireApp)
	            .CurrentUser
	            .GetToken(true)
	            .AddOnCompleteListener(this, new GmsTaskCompletion((sender, e) => 
	{
		var task = (e as GmsTaskCompletion.GmsTaskEvent).task;
		if (task.IsSuccessful)
		{
			var tokenResult = task.Result as GetTokenResult;
			Log.Debug(App.TAG, tokenResult.Token);
		}
	}));
