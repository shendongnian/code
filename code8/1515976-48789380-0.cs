        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Foundation;
    using UIKit;
    using System.Threading.Tasks;
    using Plugin.Geolocator.Abstractions;
    using Plugin.Geolocator;
    using System.Diagnostics;
    using Xamarin.Forms;
    using abcde.iOS;
    
    [assembly: Xamarin.Forms.Dependency(typeof(GPSLocation_iOS))]
    
    namespace abcde.iOS
    {
    public class GPSLocation_iOS : IGPSLocation
    {
    public Position _position;
    
        public GPSLocation_iOS()
        {
            GetPosition();
        }
    
        public Dictionary<string, string> GetGPSLocation()
        {
        Dictionary<string, string> dictPosition = new Dictionary<string, string>();
    
        dictPosition.Add("latitude", _position.Latitude.ToString());
        dictPosition.Add("longitude", _position.Longitude.ToString());
    
          return dictPosition;
        }
    
        public async void GetPosition()
        {
            try
            {
                var locator = CrossGeolocator.Current;
    
                _position = await locator.GetLastKnownLocationAsync();
    
                if (_position == null)
                {
          locator.DesiredAccuracy = 50;
          var myPosition = await locator.GetPositionAsync();
          _position = new Position(myPosition.Latitude, myPosition.Longitude);
                }
            }
            catch (Exception ex)
            {
                               
            }
        }
