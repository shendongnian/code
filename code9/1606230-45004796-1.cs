    async Task StartListening()
    {
    	if(CrossGeolocator.Current.IsListening)
    		return;
    	
    	///This logic will run on the background automatically on iOS, however for Android and UWP you must put logic in background services. Else if your app is killed the location updates will be killed.
        await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10, true, new Plugin.Geolocator.Abstractions.ListenerSettings
                    {
                        ActivityType = Plugin.Geolocator.Abstractions.ActivityType.AutomotiveNavigation,
                        AllowBackgroundUpdates = true,
                        DeferLocationUpdates = true,
                        DeferralDistanceMeters = 1,
                        DeferralTime = TimeSpan.FromSeconds(1),
                        ListenForSignificantChanges = true,
                        PauseLocationUpdatesAutomatically = false
                    });
    
        CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
    }
    
    private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            var test = e.Position;
            listenLabel.Text = "Full: Lat: " + test.Latitude.ToString() + " Long: " + test.Longitude.ToString();
            listenLabel.Text += "\n" + $"Time: {test.Timestamp.ToString()}";
            listenLabel.Text += "\n" + $"Heading: {test.Heading.ToString()}";
            listenLabel.Text += "\n" + $"Speed: {test.Speed.ToString()}";
            listenLabel.Text += "\n" + $"Accuracy: {test.Accuracy.ToString()}";
            listenLabel.Text += "\n" + $"Altitude: {test.Altitude.ToString()}";
            listenLabel.Text += "\n" + $"AltitudeAccuracy: {test.AltitudeAccuracy.ToString()}";
        });
    }           
