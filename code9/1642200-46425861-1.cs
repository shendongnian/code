    private async Task TestUserAuthAsync(){
        var task1 = Task.Run(AuthenticateUser("username1", "password1"));
		var task2 = Task.Run(AuthenticateUser("username2", "password2"));
		
		await Task.WhenAll(task1, task2);
    }
