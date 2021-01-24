    ConnectionProfile profile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
    if (profile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
    {
        Debug.WriteLine("InternetAccess");
    }
    var signal = profile.GetSignalBars();
    Debug.WriteLine("signal is:"+signal);
    if (profile.IsWlanConnectionProfile)
    {
        Debug.WriteLine("Wifi");
    }
    else if (profile.IsWwanConnectionProfile)
    {
        Debug.WriteLine("Cellular");
    }
