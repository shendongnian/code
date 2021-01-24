    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			try
			{
				string allowedOrigin = context.OwinContext.Get<string>(DOAuthStatic.ALLOWED_CORS_ORIGINS_KEY);
				if (allowedOrigin != null)
				{
					context.OwinContext.Response.Headers[DOAuthStatic.CORS_HEADER] = allowedOrigin;
				}
				DAuthenticationResponse authResponse = await _authRepository.Authenticate(context.UserName, context.Password);
				if (!authResponse.IsAuthenticated)
				{
					context.SetError(OAuthError.InvalidGrant, $"{(int)authResponse.AuthenticateResult}:{authResponse.AuthenticateResult}");
					return;
				}
				if (authResponse.User.ChangePasswordOnLogin)
				{
					_userAuthenticationProvider.GeneratePasswordResetToken(authResponse.User);
				}
				IDictionary<string, string> props = new Dictionary<string, string>
				{
					{
						DOAuthStatic.CLIENT_NAME_KEY, context.ClientId ?? string.Empty
					}
				};
				ValidateContext(context, authResponse, props);
			}
			catch (Exception ex)
			{
				DLogOAuth.LogException(ex, "DCO0407E", "OAuthServerProvider - Error validating user");
				throw;
			}
		}
