      public static async Task<JObject> GenerateLocalAccessTokenResponse(string userName, string role, string userId, string clientId, string provider)
        {
            var tokenExpiration = TimeSpan.FromDays(1);
            var identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim("ClientId", clientId));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));
            identity.AddClaim(new Claim(ClaimTypes.Role, role));
            var data = new Dictionary<string, string>
            {
                {"userName", userName},
                {"client_id", clientId},
                {"role", role},
                {"provider", provider},
                {"userId", userId}
            };
            var props = new AuthenticationProperties(data);
            var ticket = new AuthenticationTicket(identity, props);
            var accessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
            var tokenResponse = new JObject(
                new JProperty("userName", userName),
                new JProperty("client_id", clientId),
                new JProperty("role", role),
                new JProperty("provider", provider),
                new JProperty("userId", userId),
                new JProperty("access_token", accessToken),
                new JProperty("token_type", "bearer"),
                new JProperty("expires_in", tokenExpiration.TotalSeconds.ToString()),
                new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
                );
            return tokenResponse;
        }
