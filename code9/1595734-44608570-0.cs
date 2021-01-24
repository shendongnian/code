    public async override void OnAppearing()
    {
        var pos = await GetCurrentLocation();
        var map = new Map(MapSpan.FromCenterAndRadius(
            pos, Distance.FromMiles(.3)))
        {
            MapType = MapType.Street,
            IsShowingUser = true,
            HeightRequest = 100,
            WidthRequest = 960,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HasScrollEnabled = true,
            HasZoomEnabled = true
        };
        var stack = new StackLayout { Spacing = 0 };
        stack.Children.Add(map);
        Content = stack;
    }
    private async Position GetCurrentLocation()
    {
        var locator = CrossGeolocator.Current;
        locator.DesiredAccuracy = 50;
        var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
        return position;
    }
