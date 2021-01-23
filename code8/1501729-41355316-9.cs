    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOpenIdConnectServer(options =>
            {
                // Register a new ephemeral key, that is discarded when the application
                // shuts down. Tokens signed using this key are automatically invalidated.
                // This method should only be used during development.
                options.SigningCredentials.AddEphemeralKey();
    
                // Enable the authorization endpoint.
                options.AuthorizationEndpointPath = new PathString("/connect/authorize");
    
                // During development, you can disable the HTTPS requirement.
                options.AllowInsecureHttp = true;
    
                // Implement the ValidateAuthorizationRequest event to validate the response_type,
                // the client_id and the redirect_uri provided by the client application.
                options.Provider.OnValidateAuthorizationRequest = context =>
                {
                    if (!context.Request.IsImplicitFlow())
                    {
                        context.Reject(
                            error: OpenIdConnectConstants.Errors.UnsupportedResponseType,
                            description: "The provided response_type is invalid.");
    
                        return Task.FromResult(0);
                    }
    
                    if (!string.Equals(context.ClientId, "spa-application", StringComparison.Ordinal))
                    {
                        context.Reject(
                            error: OpenIdConnectConstants.Errors.InvalidClient,
                            description: "The provided client_id is invalid.");
    
                        return Task.FromResult(0);
                    }
    
                    if (!string.Equals(context.RedirectUri, "http://spa-app.com/redirect_uri", StringComparison.Ordinal))
                    {
                        context.Reject(
                            error: OpenIdConnectConstants.Errors.InvalidClient,
                            description: "The provided redirect_uri is invalid.");
    
                        return Task.FromResult(0);
                    }
    
                    context.Validate();
    
                    return Task.FromResult(0);
                };
    
                // Implement the HandleAuthorizationRequest event to return an implicit authorization response.
                options.Provider.OnHandleAuthorizationRequest = context =>
                {
                    // Retrieve the Windows principal: if a null value is returned, apply an HTTP challenge
                    // to allow IIS/SystemWeb to initiate the unmanaged integrated authentication dance.
                    var principal = context.OwinContext.Authentication.User as WindowsPrincipal;
                    if (principal == null)
                    {
                        context.OwinContext.Authentication.Challenge();
                        return Task.FromResult(0);
                    }
    
                    // Create a new ClaimsIdentity containing the claims that
                    // will be used to create an id_token, a token or a code.
                    var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationType);
    
                    // Note: the JWT/OIDC "sub" claim is required by OpenIddict
                    // but is not automatically added to the Windows principal, so
                    // the primary security identifier is used as a fallback value.
                    identity.AddClaim(OpenIdConnectConstants.Claims.Subject, principal.GetClaim(ClaimTypes.PrimarySid));
    
                    // Note: by default, claims are NOT automatically included in the access and identity tokens.
                    // To allow OpenIddict to serialize them, you must attach them a destination, that specifies
                    // whether they should be included in access tokens, in identity tokens or in both.
    
                    foreach (var claim in principal.Claims)
                    {
                        // In this sample, every claim is serialized in both the access and the identity tokens.
                        // In a real world application, you'd probably want to exclude confidential claims
                        // or apply a claims policy based on the scopes requested by the client application.
                        claim.SetDestinations(OpenIdConnectConstants.Destinations.AccessToken,
                                              OpenIdConnectConstants.Destinations.IdentityToken);
    
                        // Copy the claim from the Windows principal to the new identity.
                        identity.AddClaim(claim);
                    }
    
                    context.Validate(identity);
    
                    return Task.FromResult(0);
                };
            });
        }
    }
