    public Task<bool> IsValidTouchIDAsync()
    {
    	var tcs = new TaskCompletionSource<bool>();
    
        var replyHandler = new LAContextReplyHandler((success, er) => tcs.SetResult(success);
    	
        context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, "Enter Touch ID", replyHandler);
        return tcs.Task;
    } 
