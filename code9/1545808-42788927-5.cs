    //SomeType needs to be the same type that locator.GetPositionAsync() returns
    //Also C# naming conventions say that any async methods should end with "Async", obviously not required but it will make your life easier later
    public async Task<SomeType> getCurrentPositionAsync() 
    {
        SomeType position = null;
        try
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
            Debug.WriteLine("Position Status: {0}", position.Timestamp);
            Debug.WriteLine("Position Latitude: {0}", position.Latitude);
            Debug.WriteLine("Position Longitude: {0}", position.Longitude);            
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
        }
        return position;
    }
