    var auth = await HttpContext.AuthenticateAsync(AuthenticationScheme.Cookie)
                                .ConfigureAwait(false);
    auth.Properties.UpdateTokenValue(OpenIdConnectParameterNames.AccessToken,
                                     newToken.AccessToken);
    auth.Properties.UpdateTokenValue(OpenIdConnectParameterNames.RefreshToken, 
                                     newToken.RefreshToken);
    await HttpContext.SignInAsync(auth.Principal, auth.Properties)
                     .ConfigureAwait(false);
