    public async void GetPosition()
    {
        var locator = CrossGeolocator.Current;
        locator.DesiredAccuracy = 50;
        var myPosition = await locator.GetPositionAsync();
        _position = new Position(myPosition.Latitude, myPosition.Longitude);
    }
