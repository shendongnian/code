    #region Events
    public readonly static RoutedEvent NetworkStatusEvent =
           EventManager.RegisterRoutedEvent(
               "NetworkStatusEvent",
               RoutingStrategy.Tunnel,
               typeof(RoutedEventHandler),
               typeof(NetworkStatusViewModel));
    #endregion
       public void NetworkStatus_Changed(Object sender, RoutedEventArgs e)
        {
            Image = "home-scanner";
            IsAvailable = NetworkStatus.IsAvailable ? true : false;
            TextLegend = "sfsdfhf";
            //RaiseEvent(new RoutedEventArgs(NetworkStatusViewModel.GreetEvent, this));
            e.Handled = true;
        }
