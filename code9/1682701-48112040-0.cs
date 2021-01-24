    public class MainPage : ContentPage
    {
        ...
        public MainPage()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
        }
    
        protected async override void OnAppearing()
        {
            position = await GetPosition();
            
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(0.3)));
        }
        
        async Task<Plugin.Geolocator.Abstractions.Position> GetPosition()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
    
            Plugin.Geolocator.Abstractions.Position position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5));
    
            return position;
        }
    }
