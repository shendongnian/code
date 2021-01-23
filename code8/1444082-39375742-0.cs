    public partial class RadarHome : ContentPage
        {
    
            private readonly CrossGeolocator _locator;
            private double BetaLat;
            private double BetaLog;
    
            public RadarHome()
            {
                MyLocationTracker msi;
    
                _locator = CrossGeolocator.Current;
    
                if (_locator.IsGeolocationEnabled == false)
                {
    
                    if (Device.OS == TargetPlatform.Android)
                    {
    
                        msi.locationObtained += (object Esender, MyLocationEventArgs ew) => {
                            Debug.WriteLine(ew.lat);
                        };
                        msi.ObtainMyLocation();
    
    
                    }
    
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        msi = DependencyService.Get<MyLocationTracker>();
                        msi.locationObtained += (object Jsender, MyLocationEventArgs je) =>
                        {
                            Debug.WriteLine(je.lat);
                        };
                        msi.ObtainMyLocation();
                    }
    
                }
    
                _locator.DesiredAccuracy = 50;
    
                GetPositionAsynchronously();
    
                string str = string.Format("https://forecast.io/?mobile=1#/f/Lat:{0} , Long: {1}", BetaLat, BetaLog);
    
                var client = new System.Net.Http.HttpClient();
    
                client.BaseAddress = new Uri(str);
            }
    
            private async void GetPositionAsynchronously()
            {
                //will run asynchronously in a diff thread
            	var position = await _locator.GetPositionAsync(timeoutMilliseconds: 100000);
    
                BetaLat = position.Latitude; //will work
                BetaLog = position.Longitude; // will work      
            }
    
    
        }
