    /// <summary>
    /// Event handler when connection changes
    /// </summary>
    event ConnectivityChangedEventHandler ConnectivityChanged; 
    You will get a ConnectivityChangeEventArgs with the status if you are connected or not:
    
    public class ConnectivityChangedEventArgs : EventArgs
    {
      public bool IsConnected { get; set; }
    }
    
    public delegate void ConnectivityChangedEventHandler(object sender, ConnectivityChangedEventArgs e);
    CrossConnectivity.Current.ConnectivityChanged += async (sender, args) =>
      {
          Debug.WriteLine($"Connectivity changed to {args.IsConnected}");
      };
