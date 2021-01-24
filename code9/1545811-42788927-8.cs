    public class PositionPage
    {
        public static async Task<PositionPage> Create()
        {
            var position = await GetCurrentPositionAsync();
            var map = new Map(
                MapSpan.FromCenterAndRadius(
                    new Position(45.452481, 9.166337),
                    Distance.FromMiles(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            
    
            var positionPage= new PositionPage();
            positionPage.Content = stack;
            return positionPage;
        }
        private PositionPage()
        {
        }
        //SomeType needs to be the same type that locator.GetPositionAsync() returns
        //Also C# naming conventions say that any async methods should end with "Async", obviously not required but it will make your life easier later
        public async Task<SomeType> GetCurrentPositionAsync() 
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                Debug.WriteLine("Position Status: {0}", position.Timestamp);
                Debug.WriteLine("Position Latitude: {0}", position.Latitude);
                Debug.WriteLine("Position Longitude: {0}", position.Longitude);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
        }
    }
