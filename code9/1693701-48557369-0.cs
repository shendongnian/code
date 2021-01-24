    try
    {
        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
        if (status != PermissionStatus.Granted)
        {
            if(await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
            {
                await DisplayAlert("Need location", "Gunna need that location", "OK");
            }
    
            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
    		//Best practice to always check that the key exists
    		if(results.ContainsKey(Permission.Location))
            	status = results[Permission.Location];
        }
    
        if (status == PermissionStatus.Granted)
        {
            var results = await CrossGeolocator.Current.GetPositionAsync(10000);
            LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
        }
        else if(status != PermissionStatus.Unknown)
        {
            await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
        }
    }
    catch (Exception ex)
    {
    
        LabelGeolocation.Text = "Error: " + ex;
    }
