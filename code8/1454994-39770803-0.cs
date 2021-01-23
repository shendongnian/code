    LoginResultSet result = new LoginResultSet();
    Task<LoginResultSet> loginTask = new Task<LoginResultSet>(() =>
    {
	    return WCFClient.TryClientLogin(Environment.MachineName);
    });
    loginTask.Start();
    await Task.WhenAll(loginTask);
    result = loginTask.Result;
