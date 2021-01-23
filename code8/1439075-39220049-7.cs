    MyLocationTracker msi;
 
        double BetaLat;
		double BetaLog;
  
				var locator = CrossGeolocator.Current;
				if (locator.IsGeolocationEnabled == false)
				{
					if (Device.OS == TargetPlatform.Android)
					{
						msi = DependencyService.Get<MyLocationTracker>();
						msi.locationObtained += (object Esender, MyLocationEventArgs ew) => {
							Console.WriteLine(ew.lat);
						};
						msi.ObtainMyLocation();
					}
					else if (Device.OS == TargetPlatform.iOS)
					{
						msi = DependencyService.Get<MyLocationTracker>();
						msi.locationObtained += (object Jsender, MyLocationEventArgs je) =>
						{
							Console.WriteLine(je.lat);
						};
						msi.ObtainMyLocation();
					}
				}
					locator.DesiredAccuracy = 50;
					var position =  locator.GetPositionAsync(timeoutMilliseconds: 100000);
					
				
					
					BetaLat = position.Latitude;
					BetaLog = position.Longitude;
    string str = string.Format("https://forecast.io/?mobile=1#/f/Lat:{0} , Long: {1}", BetaLat, BetaLog);
					
			
      var client = new System.Net.Http.HttpClient();
     
     client.BaseAddress = new Uri(str);
---------------------
