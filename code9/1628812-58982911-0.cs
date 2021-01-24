    public bool InitAuthenticatedClientAsync()
    {
        bool bSuccess = true;
    
        _graphClient = new GraphServiceClient(
            new DelegateAuthenticationProvider(
                async (requestMessage) =>
                {
                    try
                    {
                        var accounts = await PublicClientApp.GetAccountsAsync();
                        // See: https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/MSAL.NET-3-released#acquiring-a-token-also-got-simpler
                        _AuthResult = await PublicClientApp.AcquireTokenSilent(_Scopes, accounts.FirstOrDefault()).ExecuteAsync();
                    }
                    catch (MsalUiRequiredException ex)
                    {
                        // A MsalUiRequiredException happened on AcquireTokenSilentAsync. This indicates you need to call AcquireTokenAsync to acquire a token
                        System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");
    
                        try
                        {
                            // See: https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/MSAL.NET-3-released#acquiring-a-token-also-got-simpler
                            _AuthResult = await PublicClientApp.AcquireTokenInteractive(_Scopes).ExecuteAsync();
                        }
                        catch (MsalException msalex)
                        {
                            SimpleLog.Log(msalex);
                            Console.WriteLine("GetAuthenticatedClientAsync: Acquire token error. See log.");
                            bSuccess = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        SimpleLog.Log(ex);
                        Console.WriteLine("GetAuthenticatedClientAsync: Acquire token silently error. See log.");
                        bSuccess = false;
                    }
    
                    if(bSuccess)
                    {
                        // Append the access token to the request.
                        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", _AuthResult.AccessToken);
    
                        // Get event times in the current time zone.
                        requestMessage.Headers.Add("Prefer", "outlook.timezone=\"" + TimeZoneInfo.Local.Id + "\"");
                    }
                }));
    
        return bSuccess;
    }
    public async Task<bool> BuildCalendarsList()
    {
        bool bSuccess = true;
    
        if (_graphClient == null)
            return false;
    
        try
        {
            var calendars = await _graphClient
                                 .Me
                                 .Calendars
                                 .Request()
                                 .GetAsync();
    
    
            foreach (Calendar oCalendar in calendars)
            {
                _CalendarInfo.AddCalendarEntry(oCalendar.Name, oCalendar.Id);
            }
    
            bSuccess = SaveCalendarInfo();
        }
        catch (Exception ex)
        {
            SimpleLog.Log(ex);
            Console.WriteLine("BuildCalendarsList: See error log.");
            bSuccess = false;
        }
    
        return bSuccess;
    }
