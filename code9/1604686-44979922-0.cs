    public class CustomOidcHandler : OpenIdConnectAuthenticationHandler
    {
        private const string HandledResponse = "HandledResponse";
        private readonly ILogger _logger;
        private OpenIdConnectConfiguration _configuration;
        public CustomOidcHandler(ILogger logger) : base(logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Invoked to process incoming authentication messages.
        /// </summary>
        /// <returns>An <see cref="AuthenticationTicket"/> if successful.</returns>
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            // Allow login to be constrained to a specific path. Need to make this runtime configurable.
            if (Options.CallbackPath.HasValue && Options.CallbackPath != (Request.PathBase + Request.Path))
                return null;
            OpenIdConnectMessage openIdConnectMessage = null;
            if (string.Equals(Request.Method, "GET", StringComparison.OrdinalIgnoreCase))
                openIdConnectMessage = new OpenIdConnectMessage(Request.Query);
            if (openIdConnectMessage == null)
                return null;
            ExceptionDispatchInfo authFailedEx = null;
            try
            {
                return await CreateAuthenticationTicket(openIdConnectMessage).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                // We can't await inside a catch block, capture and handle outside.
                authFailedEx = ExceptionDispatchInfo.Capture(exception);
            }
            if (authFailedEx != null)
            {
                _logger.WriteError("Exception occurred while processing message: ", authFailedEx.SourceException);
                // Refresh the configuration for exceptions that may be caused by key rollovers. The user can also request a refresh in the notification.
                if (Options.RefreshOnIssuerKeyNotFound && authFailedEx.SourceException.GetType() == typeof(SecurityTokenSignatureKeyNotFoundException))
                    Options.ConfigurationManager.RequestRefresh();
                var authenticationFailedNotification = new AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>(Context, Options)
                {
                    ProtocolMessage = openIdConnectMessage,
                    Exception = authFailedEx.SourceException
                };
                await Options.Notifications.AuthenticationFailed(authenticationFailedNotification).ConfigureAwait(false);
                if (authenticationFailedNotification.HandledResponse)
                    return GetHandledResponseTicket();
                if (authenticationFailedNotification.Skipped)
                    return null;
                authFailedEx.Throw();
            }
            return null;
        }
        private async Task<AuthenticationTicket> CreateAuthenticationTicket(OpenIdConnectMessage openIdConnectMessage)
        {
            var messageReceivedNotification =
                new MessageReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>(Context, Options)
                {
                    ProtocolMessage = openIdConnectMessage
                };
            await Options.Notifications.MessageReceived(messageReceivedNotification).ConfigureAwait(false);
            if (messageReceivedNotification.HandledResponse)
            {
                return GetHandledResponseTicket();
            }
            if (messageReceivedNotification.Skipped)
            {
                return null;
            }
            // runtime always adds state, if we don't find it OR we failed to 'unprotect' it this is not a message we
            // should process.
            AuthenticationProperties properties = GetPropertiesFromState(openIdConnectMessage.State);
            if (properties == null)
            {
                _logger.WriteWarning("The state field is missing or invalid.");
                return null;
            }
            // devs will need to hook AuthenticationFailedNotification to avoid having 'raw' runtime errors displayed to users.
            if (!string.IsNullOrWhiteSpace(openIdConnectMessage.Error))
            {
                throw new OpenIdConnectProtocolException(
                    string.Format(CultureInfo.InvariantCulture,
                        openIdConnectMessage.Error,
                        "Exception_OpenIdConnectMessageError", openIdConnectMessage.ErrorDescription ?? string.Empty,
                        openIdConnectMessage.ErrorUri ?? string.Empty));
            }
            // tokens.Item1 contains id token
            // tokens.Item2 contains access token
            Tuple<string, string> tokens = await GetTokens(openIdConnectMessage.Code, Options)
                .ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(openIdConnectMessage.IdToken))
                openIdConnectMessage.IdToken = tokens.Item1;
            var securityTokenReceivedNotification =
                new SecurityTokenReceivedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>(Context,
                    Options)
                {
                    ProtocolMessage = openIdConnectMessage,
                };
            await Options.Notifications.SecurityTokenReceived(securityTokenReceivedNotification).ConfigureAwait(false);
            if (securityTokenReceivedNotification.HandledResponse)
                return GetHandledResponseTicket();
            if (securityTokenReceivedNotification.Skipped)
                return null;
            if (_configuration == null)
                _configuration = await Options.ConfigurationManager.GetConfigurationAsync(Context.Request.CallCancelled)
                    .ConfigureAwait(false);
            // Copy and augment to avoid cross request race conditions for updated configurations.
            TokenValidationParameters tvp = Options.TokenValidationParameters.Clone();
            IEnumerable<string> issuers = new[] {_configuration.Issuer};
            tvp.ValidIssuers = tvp.ValidIssuers?.Concat(issuers) ?? issuers;
            tvp.IssuerSigningTokens = tvp.IssuerSigningTokens?.Concat(_configuration.SigningTokens) ?? _configuration.SigningTokens;
            SecurityToken validatedToken;
            ClaimsPrincipal principal =
                Options.SecurityTokenHandlers.ValidateToken(openIdConnectMessage.IdToken, tvp, out validatedToken);
            ClaimsIdentity claimsIdentity = principal.Identity as ClaimsIdentity;
            var claims = await GetClaims(tokens.Item2).ConfigureAwait(false);
            AddClaim(claims, claimsIdentity, "sub", ClaimTypes.NameIdentifier, Options.AuthenticationType);
            AddClaim(claims, claimsIdentity, "given_name", ClaimTypes.GivenName);
            AddClaim(claims, claimsIdentity, "family_name", ClaimTypes.Surname);
            AddClaim(claims, claimsIdentity, "preferred_username", ClaimTypes.Name);
            AddClaim(claims, claimsIdentity, "email", ClaimTypes.Email);
            // claims principal could have changed claim values, use bits received on wire for validation.
            JwtSecurityToken jwt = validatedToken as JwtSecurityToken;
            AuthenticationTicket ticket = new AuthenticationTicket(claimsIdentity, properties);
            if (Options.ProtocolValidator.RequireNonce)
            {
                if (String.IsNullOrWhiteSpace(openIdConnectMessage.Nonce))
                    openIdConnectMessage.Nonce = jwt.Payload.Nonce;
                // deletes the nonce cookie
                RetrieveNonce(openIdConnectMessage);
            }
            // remember 'session_state' and 'check_session_iframe'
            if (!string.IsNullOrWhiteSpace(openIdConnectMessage.SessionState))
                ticket.Properties.Dictionary[OpenIdConnectSessionProperties.SessionState] = openIdConnectMessage.SessionState;
            if (!string.IsNullOrWhiteSpace(_configuration.CheckSessionIframe))
                ticket.Properties.Dictionary[OpenIdConnectSessionProperties.CheckSessionIFrame] =
                    _configuration.CheckSessionIframe;
            if (Options.UseTokenLifetime)
            {
                // Override any session persistence to match the token lifetime.
                DateTime issued = jwt.ValidFrom;
                if (issued != DateTime.MinValue)
                {
                    ticket.Properties.IssuedUtc = issued.ToUniversalTime();
                }
                DateTime expires = jwt.ValidTo;
                if (expires != DateTime.MinValue)
                {
                    ticket.Properties.ExpiresUtc = expires.ToUniversalTime();
                }
                ticket.Properties.AllowRefresh = false;
            }
            var securityTokenValidatedNotification =
                new SecurityTokenValidatedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions>(Context,
                    Options)
                {
                    AuthenticationTicket = ticket,
                    ProtocolMessage = openIdConnectMessage,
                };
            await Options.Notifications.SecurityTokenValidated(securityTokenValidatedNotification).ConfigureAwait(false);
            if (securityTokenValidatedNotification.HandledResponse)
            {
                return GetHandledResponseTicket();
            }
            if (securityTokenValidatedNotification.Skipped)
            {
                return null;
            }
            // Flow possible changes
            ticket = securityTokenValidatedNotification.AuthenticationTicket;
            // there is no hash of the code (c_hash) in the jwt obtained from the server
            // I don't know how to perform the validation using ProtocolValidator without the hash
            // that is why the code below is commented
            //var protocolValidationContext = new OpenIdConnectProtocolValidationContext
            //{
            //    AuthorizationCode = openIdConnectMessage.Code,
            //    Nonce = nonce
            //};
            //Options.ProtocolValidator.Validate(jwt, protocolValidationContext);
            if (openIdConnectMessage.Code != null)
            {
                var authorizationCodeReceivedNotification = new AuthorizationCodeReceivedNotification(Context, Options)
                {
                    AuthenticationTicket = ticket,
                    Code = openIdConnectMessage.Code,
                    JwtSecurityToken = jwt,
                    ProtocolMessage = openIdConnectMessage,
                    RedirectUri =
                        ticket.Properties.Dictionary.ContainsKey(OpenIdConnectAuthenticationDefaults.RedirectUriUsedForCodeKey)
                            ? ticket.Properties.Dictionary[OpenIdConnectAuthenticationDefaults.RedirectUriUsedForCodeKey]
                            : string.Empty,
                };
                await Options.Notifications.AuthorizationCodeReceived(authorizationCodeReceivedNotification)
                    .ConfigureAwait(false);
                if (authorizationCodeReceivedNotification.HandledResponse)
                {
                    return GetHandledResponseTicket();
                }
                if (authorizationCodeReceivedNotification.Skipped)
                {
                    return null;
                }
                // Flow possible changes
                ticket = authorizationCodeReceivedNotification.AuthenticationTicket;
            }
            return ticket;
        }
        private static void AddClaim(IEnumerable<Tuple<string, string>> claims, ClaimsIdentity claimsIdentity, string key, string claimType, string issuer = null)
        {
            string subject = claims
                .Where(it => it.Item1 == key)
                .Select(x => x.Item2).SingleOrDefault();
            if (!string.IsNullOrWhiteSpace(subject))
                claimsIdentity.AddClaim(
                    new System.Security.Claims.Claim(claimType, subject, ClaimValueTypes.String, issuer));
        }
        private async Task<Tuple<string, string>> GetTokens(string authorizationCode, OpenIdConnectAuthenticationOptions options)
        {
            // exchange authorization code at authorization server for an access and refresh token
            Dictionary<string, string> post = null;
            post = new Dictionary<string, string>
            {
                {"client_id", options.ClientId},
                {"client_secret", options.ClientSecret},
                {"grant_type", "authorization_code"},
                {"code", authorizationCode},
                {"redirect_uri", options.RedirectUri}
            };
            string content;
            using (var client = new HttpClient())
            {
                var postContent = new FormUrlEncodedContent(post);
                var response = await client.PostAsync(options.Authority.TrimEnd('/') + "/token", postContent)
                    .ConfigureAwait(false);
                content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            // received tokens from authorization server
            var json = JObject.Parse(content);
            var accessToken = json["access_token"].ToString();
            string idToken = null;
            if (json["id_token"] != null)
                idToken = json["id_token"].ToString();
            return new Tuple<string, string>(idToken, accessToken);
        }
        private async Task<IEnumerable<Tuple<string, string>>> GetClaims(string accessToken)
        {
            string userInfoEndpoint = Options.Authority.TrimEnd('/') + "/userinfo";
            var userInfoClient = new UserInfoClient(new Uri(userInfoEndpoint), accessToken);
            var userInfoResponse = await userInfoClient.GetAsync().ConfigureAwait(false);
            var claims = userInfoResponse.Claims;
            return claims;
        }
        private static AuthenticationTicket GetHandledResponseTicket()
        {
            return new AuthenticationTicket(null, new AuthenticationProperties(new Dictionary<string, string>() { { HandledResponse, "true" } }));
        }
        private AuthenticationProperties GetPropertiesFromState(string state)
        {
            // assume a well formed query string: <a=b&>OpenIdConnectAuthenticationDefaults.AuthenticationPropertiesKey=kasjd;fljasldkjflksdj<&c=d>
            int startIndex = 0;
            if (string.IsNullOrWhiteSpace(state) || (startIndex = state.IndexOf("OpenIdConnect.AuthenticationProperties", StringComparison.Ordinal)) == -1)
            {
                return null;
            }
            int authenticationIndex = startIndex + "OpenIdConnect.AuthenticationProperties".Length;
            if (authenticationIndex == -1 || authenticationIndex == state.Length || state[authenticationIndex] != '=')
            {
                return null;
            }
            // scan rest of string looking for '&'
            authenticationIndex++;
            int endIndex = state.Substring(authenticationIndex, state.Length - authenticationIndex).IndexOf("&", StringComparison.Ordinal);
            // -1 => no other parameters are after the AuthenticationPropertiesKey
            if (endIndex == -1)
            {
                return Options.StateDataFormat.Unprotect(Uri.UnescapeDataString(state.Substring(authenticationIndex).Replace('+', ' ')));
            }
            else
            {
                return Options.StateDataFormat.Unprotect(Uri.UnescapeDataString(state.Substring(authenticationIndex, endIndex).Replace('+', ' ')));
            }
        }
    }
    public static class CustomOidcAuthenticationExtensions
    {
        /// <summary>
        /// Adds the <see cref="OpenIdConnectAuthenticationMiddleware"/> into the OWIN runtime.
        /// </summary>
        /// <param name="app">The <see cref="IAppBuilder"/> passed to the configuration method</param>
        /// <param name="openIdConnectOptions">A <see cref="OpenIdConnectAuthenticationOptions"/> contains settings for obtaining identities using the OpenIdConnect protocol.</param>
        /// <returns>The updated <see cref="IAppBuilder"/></returns>
        public static IAppBuilder UseCustomOidcAuthentication(this IAppBuilder app, OpenIdConnectAuthenticationOptions openIdConnectOptions)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (openIdConnectOptions == null)
                throw new ArgumentNullException(nameof(openIdConnectOptions));
            return app.Use(typeof(CustomOidcMiddleware), app, openIdConnectOptions);
        }
    }
