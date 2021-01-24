    protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                SetContentView(Resource.Layout.Main);
    
                //Initialize buttons:
    
                Button StartButton = FindViewById<Button>(Resource.Id.startbutton);
                TextView txtTestGps = FindViewById<TextView>(Resource.Id.GpsTest);
                
                Task.Run(async () => {
                    await ShowGpsCoordinates(StartButton, txtTestGps);
                }
            }
    
            private async Task ShowGpsCoordinates(Button StartButton, TextView txtTestGps) 
            {
               double xyOut = await GiveGpsLocation();
                
    
                StartButton.Click += (sender, e) =>
                {
                    txtTestGps.Text = xyOut.ToString();   
                };
            }
               
            private async Task<double> GiveGpsLocation()
            {
                double DoubleWithCoordinates = 0.0;
    
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
    
                var position =  await locator.GetPositionAsync(10000);
    
                // Console.WriteLine("Position Status: {0}", position.Timestamp);
                // Console.WriteLine("Position Latitude: {0}", position.Latitude);
                // Console.WriteLine("Position Longitude: {0}", position.Longitude);
    
                DoubleWithCoordinates = position.Latitude; 
    
                return DoubleWithCoordinates;  
            }
    
        }
