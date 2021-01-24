    /// <summary>
    /// Event handler when connection type changes
    /// </summary>
    event ConnectivityTypeChangedEventHandler ConnectivityTypeChanged;
    When this occurs an event will be triggered with EventArgs that have the most recent information:
    
    public class ConnectivityTypeChangedEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }
        public IEnumerable<ConnectionType> ConnectionTypes { get; set; }
    }
    public delegate void ConnectivityTypeChangedEventHandler(object sender, ConnectivityTypeChangedEventArgs e);
    Example:
    
    CrossConnectivity.Current.ConnectivityTypeChanged += async (sender, args) =>
      {
          Debug.WriteLine($"Connectivity changed to {args.IsConnected}");
          foreach(var t in args.ConnectionTypes)
            Debug.WriteLine($"Connection Type {t}");
      };
