	public async Task<Token> CallSomethingAsync()
	{
		try
		{
			var result = await client.Authorization.Create(newAuthorization);
			result.Token;
		}
		catch ( Octokit.TwoFactorRequiredException )
		{
			_navigationService.NavigateAsync($"{nameof(TwoFactorAuthPage)}", animated: false);
		}
	}
