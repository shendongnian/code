    LocationManager locationManager = (LocationManager)GetSystemService(Context.LocationService);
    IList<String> lp = locationManager.AllProviders;
    foreach (String item in lp)
    {
        Log.Debug("TAG", "Available Location Service ：" + item);
    }
    //A class indicating the application criteria for selecting a location provider.
    Criteria criteria = new Criteria();
    //Indicates whether the provider is allowed to incur monetary cost.
    criteria.CostAllowed = false;
    //Set desired accuracy of location Accuracy
    criteria.Accuracy = Accuracy.Coarse; 
     
    //Returns the name of the provider that best meets the given criteria                 
    String providerName = locationManager.GetBestProvider(criteria, true);
    Log.Debug("8023", "------Location Service：" + providerName);
    //Directly choose a Location Provider
    //String providerName = LocationManager.GpsProvider;
    Location location = locationManager.GetLastKnownLocation(providerName);
    double lat = location.Latitude;
    double lng = location.Longitude;
    txtLoc.Text = "Latitude = " + lat + ", Longitude = " + lng;
    
