    async Task GetGpsData()
    {
        var tcs = new TaskCompletionSource<bool>();
    
        Device.BeginInvokeOnMainThread(() => {
            try
            {
                Location loc = new Location();
                GpsData = locService.GetLocation();
                a = GpsData.Latitude;
                b = GpsData.Longitude;
                tcs.SetResult(true);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        });
        
        return tcs.Task;
    }
