    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                // get your position
                var centerPos = await GetCurrentLocation();
                // init map => center on the position
                uiMap.MoveToRegion(MapSpan.FromCenterAndRadius(centerPos, Distance.FromMiles(.3)).WithZoom(20));
            }
            catch(Exception e)
            {
                // notify user here
                // log exception
            }
        }
        private async Task<Position> GetCurrentLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            return position;
        }
    }
