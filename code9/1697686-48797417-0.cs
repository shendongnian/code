    public class Geolocation
    { 
        string _latLongText, _latLongAccuracyText, _altitudeText, _altitudeAccuracyText;
        public Geolocation()
        {
            StartListeningForGeoloactionUpdates.GetAwaiter().GetResult();
        }
        public string LatLongText
        {
            get => _latLongText;
            set => _latLongText = value;
        }
    
        public string LatLongAccuracyText
        {
            get => _latLongAccuracyText;
            set => _latLongAccuracyText = value;
        }
    
        public string AltitudeText
        {
            get => _altitudeText;
            set => _altitudeText = value;
        }
    
        public string AltitudeAccuracyText
        {
            get => _altitudeAccuracyText;
            set => _altitudeAccuracyText = value;
        }
    
        Task StartListeningForGeoloactionUpdates()
        {
            bool isGeolocationAvailable = CrossGeolocator.IsSupported
                                        && CrossGeolocator.Current.IsGeolocationAvailable
                                        && CrossGeolocator.Current.IsGeolocationEnabled;
    
            if (isGeolocationAvailable)
            {
                CrossGeolocator.Current.PositionChanged += HandlePositionChanged;
                return CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(1), 10);
            }
    
            LatLongText = "Geolocation Unavailable";
            return Task.CompletedTask;
        }
    
        void HandlePositionChanged(object sender, PositionEventArgs e)
        {
            AltitudeAccuracyText = $"{ConvertDoubleToString(e.Position.AltitudeAccuracy, 0)}m";
            AltitudeText = $"{ConvertDoubleToString(e.Position.Altitude, 2)}m";
            LatLongAccuracyText = $"{ConvertDoubleToString(e.Position.Accuracy, 0)}m";
            LatLongText = $"{ConvertDoubleToString(e.Position.Latitude, 2)}, {ConvertDoubleToString(e.Position.Longitude, 2)}";
    
            string ConvertDoubleToString(double number, int decimalPlaces) => number.ToString($"F{decimalPlaces}");
        }
    }
