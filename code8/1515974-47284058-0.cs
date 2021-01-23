    using Plugin.Geolocator;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Maps;
    using Xamarin.Forms.Xaml;
    namespace MapApp
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class MapPage : ContentPage
        {
            private Position _position;
            public MapPage()
            {
                InitializeComponent();
    
                var map = new Map(
                  MapSpan.FromCenterAndRadius(
                          new Position(37, -122), Distance.FromMiles(0.3)))
                {
                    IsShowingUser = true,
                    HeightRequest = 100,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
    
    
    
                if (IsLocationAvailable())
                {
                    GetPosition();
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(_position, Distance.FromMiles(1)));
    
                }
    
                map.MapType = MapType.Street;
                var stack = new StackLayout { Spacing = 0 };
                stack.Children.Add(map);
                Content = stack;
    
            }
    
            public bool IsLocationAvailable()
            {
                if (!CrossGeolocator.IsSupported)
                    return false;
    
                return CrossGeolocator.Current.IsGeolocationAvailable;
            }
            public async void GetPosition()
            {
                Plugin.Geolocator.Abstractions.Position position = null;
                try
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 100;
    
                    position = await locator.GetLastKnownLocationAsync();
    
                    if (position != null)
                    {
                        _position = new Position(position.Latitude, position.Longitude);
                        //got a cahched position, so let's use it.
                        return;
                    }
    
                    if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                    {
                        //not available or enabled
                        return;
                    }
    
                    position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);
    
                }
                catch (Exception ex)
                {
                    throw ex;
                    //Display error as we have timed out or can't get location.
                }
                _position = new Position(position.Latitude, position.Longitude);
                if (position == null)
                    return;
    
            }
    
        }
    }
