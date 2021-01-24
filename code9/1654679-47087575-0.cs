    public override IAsyncOperationWithProgress<HttpResponseMessage, HttpProgress> SendRequestAsync(HttpRequestMessage request)
	{
		return AsyncInfo.Run<HttpResponseMessage, HttpProgress>(async (cancellationToken, progress) =>
		{
			var retry = true;
			if (TokenManager.TokenExists)
			{
				var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
				if (now > TokenManager.Token.ExpiresOn)
				{
					retry = false;
					await RefreshTokenAsync();
				}
				request.Headers.Authorization = new HttpCredentialsHeaderValue(TokenManager.Token.TokenType, TokenManager.Token.AccessToken);
			}
			HttpResponseMessage response = await InnerFilter.SendRequestAsync(request).AsTask(cancellationToken, progress);
			cancellationToken.ThrowIfCancellationRequested();
			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				var authHeader = response.Headers.WwwAuthenticate.SingleOrDefault(x => x.Scheme == "Bearer");
				if (authHeader != null)
				{
					var challenge = ParseChallenge(authHeader.Parameters);
					if (challenge.Error == "token_expired" && retry)
					{
						var secondRequest = request.Clone();
						var success = await RefreshTokenAsync();
						if (success)
						{
							secondRequest.Headers.Authorization = new HttpCredentialsHeaderValue(TokenManager.Token.TokenType, TokenManager.Token.AccessToken);
							response = await InnerFilter.SendRequestAsync(secondRequest).AsTask(cancellationToken, progress);
						}
					}
				}
			}
			return response;
		});
	}
    public static HttpRequestMessage Clone(this HttpRequestMessage request)
	{
		var clone = new HttpRequestMessage(request.Method, request.RequestUri)
		{
			Content = request.Content
		};
		foreach (KeyValuePair<string, object> prop in request.Properties.ToList())
		{
			clone.Properties.Add(prop);
		}
		foreach (KeyValuePair<string, string> header in request.Headers.ToList())
		{
			clone.Headers.Add(header.Key, header.Value);
		}
		return clone;
	}
