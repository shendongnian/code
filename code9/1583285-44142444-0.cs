    /// <summary>
    /// Event handler when connection changes
    /// </summary>
    event ConnectivityChangedEventHandler ConnectivityChanged; 
    
    CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
      {
        page.DisplayAlert("Connectivity Changed", "IsConnected: " + args.IsConnected.ToString(), "OK");
      };
