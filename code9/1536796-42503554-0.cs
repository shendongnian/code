    try
    {
        AuthenticationContext authenticationContext = new AuthenticationContext(aadInstance + tenantID, new ADALTokenCache(signedInUserID));
        AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenSilentAsync(graphResourceId, clientcred, new UserIdentifier(userObjectID, UserIdentifierType.UniqueId));
        return authenticationResult.AccessToken;
    }
    catch (AdalSilentTokenAcquisitionException)
    {
        //told or force the user to reauthentificate.
        return null;
    }
