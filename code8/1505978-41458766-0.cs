    string ssid = "my wifi network";
    string password = "my secret pass";
    
    var access = await WiFiAdapter.RequestAccessAsync();
    if (access == WiFiAccessStatus.Allowed)
    {
        var result = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(WiFiAdapter.GetDeviceSelector());
        if (result.Count >= 1)
        {
            firstAdapter = await WiFiAdapter.FromIdAsync(result[0].Id);
    
            await firstAdapter.ScanAsync();
    
            var report = firstAdapter.NetworkReport;
            foreach (var network in report.AvailableNetworks)
            {
                if (network.Ssid == ssid)
                {
                    WiFiConnectionResult result;
                    if (network.AvailableNetwork.SecuritySettings.NetworkAuthenticationType == Windows.Networking.Connectivity.NetworkAuthenticationType.Open80211)
                    {
                        //No security
                        result = await firstAdapter.ConnectAsync(network.AvailableNetwork, reconnectionKind);
                    }
                    else
                    {
                        // Only the password potion of the credential need to be supplied
                        var credential = new PasswordCredential();
                        credential.Password = password;
    
                        result = await firstAdapter.ConnectAsync(network.AvailableNetwork, reconnectionKind, credential);
                    }
    
                    if (result.ConnectionStatus == WiFiConnectionStatus.Success)
                    {
                        //Successfully connected to network
                    }
                    else
                    {
                        //Could not connect to network
                    }
                }
            }
        }
        else
        {
            //No WiFi Adapters detected on this machine.
        }
    }
    else
    {
        //Access denied
    }
