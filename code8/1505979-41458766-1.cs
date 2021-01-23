    enum WifiConnectResult
    {
        WifiAccessDenied,
        NoWifiDevice,
        Success,
        CouldNotConnect,
        SsidNotFound,
    }
    private async Task<WifiConnectResult> ConnectWifi(string ssid, string password)
    {
        if (password == null)
            password = "";
        var access = await WiFiAdapter.RequestAccessAsync();
        if (access != WiFiAccessStatus.Allowed)
        {
            return WifiConnectResult.WifiAccessDenied;
        }
        else
        {
            var allAdapters = await WiFiAdapter.FindAllAdaptersAsync();
            if (allAdapters.Count >= 1)
            {
                var firstAdapter = allAdapters[0];
                await firstAdapter.ScanAsync();
                var network = firstAdapter.NetworkReport.AvailableNetworks.SingleOrDefault(n => n.Ssid == ssid);
                if (network != null)
                {
                    WiFiConnectionResult wifiConnectionResult;
                    if (network.SecuritySettings.NetworkAuthenticationType == Windows.Networking.Connectivity.NetworkAuthenticationType.Open80211)
                    {
                        wifiConnectionResult = await firstAdapter.ConnectAsync(network, WiFiReconnectionKind.Automatic);
                    }
                    else
                    {
                        // Only the password potion of the credential need to be supplied
                        var credential = new Windows.Security.Credentials.PasswordCredential();
                        credential.Password = password;
                        wifiConnectionResult = await firstAdapter.ConnectAsync(network, WiFiReconnectionKind.Automatic, credential);
                    }
                    if (wifiConnectionResult.ConnectionStatus == WiFiConnectionStatus.Success)
                    {
                        return WifiConnectResult.Success;
                    }
                    else
                    {
                        return WifiConnectResult.CouldNotConnect;
                    }
                }
                else
                {
                    return WifiConnectResult.SsidNotFound;
                }
            }
            else
            {
                return WifiConnectResult.NoWifiDevice;
            }
        }
    }
