    public YourConstructor()
    {   
        NetworkChange.NetworkAvailabilityChanged += OnNetworkAvailabilityChanged;
        var isAvailable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        OnNetworkAvailabilityChanged(isAvailable);
    }
    public void OnNetworkAvailabilityChanged(bool isAvailable)
    {
        if (isAvailable)
        {
            //
        }
        else
        {
            //
        }
    }
    public void OnNetworkAvailabilityChanged(object obj, NetworkAvailabilityEventArgs eventArgs)
    {
        OnNetworkAvailabilityChanged(eventArgs.IsAvailable);
    }
