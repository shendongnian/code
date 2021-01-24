    private static bool ConnectToWifi(string profileName, WlanClient.WlanInterface wlanIface,
        Wifi wifi, string profile, Action<bool> resultCallback, Dispatcher dispatcher)
    {
        //Your connect code
        bool result;
        if (status == WifiStatus.Disconnected)
        {
            result = false;
        }
        else
        {
            result = true;
        }
        dispatcher.BeginInvoke(() => resultCallback(result));
        return result;
    }       
