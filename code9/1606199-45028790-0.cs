         public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
                CrossGeolocator.Current.AllowsBackgroundUpdates = true;
                CrossGeolocator.Current.DesiredAccuracy = 50;
                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            }
    
            protected override void OnAppearing()
            {
                base.OnAppearing();
                updateLocation();
            }
    
            private async void updateLocation()
            {
                try
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;
                    locator.AllowsBackgroundUpdates = true;
                    var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
    
                    if (position == null)
                    {
                        lblData.Text = "null gps :(";
                        return;
                    }
                    lblData.Text = string.Format("\nTime: {0} \nLat: {1} \nLong: {2} \n Altitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \n Heading: {6} \n Speed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);
    
                    mapVar.MoveToRegion(
       MapSpan.FromCenterAndRadius(
           new Position(position.Latitude,position.Longitude), Distance.FromKilometers(1)));
                    await CrossGeolocator.Current.StartListeningAsync(1, 2, true);
                }
                catch (Exception)
                {
                }
            }
    
            
            private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
            {
                if (e.Position != null)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        var position = e.Position;
                        lblData.Text = string.Format("\n\nTime: {0} \nLat: {1} \nLong: {2} \n Altitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \n Heading: {6} \n Speed: {7}",
                position.Timestamp, position.Latitude, position.Longitude,
                position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);
                        mapVar.Pins.Clear();
                        mapVar.Pins.Add(new Xamarin.Forms.Maps.Pin
                        {
                            Position = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude),
                            Type = Xamarin.Forms.Maps.PinType.Place,
                            Label = "My Location"
                        });
    
                        mapVar.MoveToRegion(
       MapSpan.FromCenterAndRadius(
           new Position(position.Latitude, position.Longitude), Distance.FromKilometers(1)));
    
                    });
                }
            }
        }
