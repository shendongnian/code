	public static class AuthConfig
	{
		public static JwtBearerAuthenticationOptions GetOptions()
		{
			var keyResolver = new KeyResolver(System.Configuration.ConfigurationManager.AppSettings["OneLoginOpenIdConfigurationDomain"]); //https://<your_domain>.onelogin.com/oidc
			return new JwtBearerAuthenticationOptions
			{
				AuthenticationMode = AuthenticationMode.Active,
				TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = System.Configuration.ConfigurationManager.AppSettings["OneLoginJWTIssuer"], //https://openid-connect.onelogin.com/oidc
					ValidAudience = System.Configuration.ConfigurationManager.AppSettings["OneLoginClientId"],
					IssuerSigningKeyResolver = (token, securityToken, identifier, paramaters) => keyResolver.GetSigningKey(identifier)
				}
			};
		}
	}
	#region Helpers
	public class KeyResolver
	{
		private readonly OpenIdConnectConfiguration openIdConfig;
		private static readonly TaskFactory TaskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);
		public KeyResolver(string domain)
		{
			var cm = new ConfigurationManager<OpenIdConnectConfiguration>($"{domain}/.well-known/openid-configuration");
			openIdConfig = TaskFactory.StartNew(async () => await cm.GetConfigurationAsync()).Unwrap().GetAwaiter().GetResult();
		}
		public SecurityKey GetSigningKey(SecurityKeyIdentifier identifier)
		{
			// Find the security token which matches the identifier
			var securityToken = openIdConfig.SigningTokens.FirstOrDefault(t =>
			{
				// Each identifier has multiple clauses. Try and match for each
				foreach (var securityKeyIdentifierClause in identifier)
					if (t.MatchesKeyIdentifierClause(securityKeyIdentifierClause))
						return true;
				return false;
			});
			// Return the first key of the security token (if found)
			return securityToken?.SecurityKeys.FirstOrDefault();
		}
	}
	#endregion
