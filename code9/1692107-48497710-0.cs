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
            status = results[Permission.Location];
         }
         if (status == PermissionStatus.Granted)
         {
             //Permission granted, do what you want do.
         }
         else if(status != PermissionStatus.Unknown)
         {
             await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
         }
    }
    catch (Exception ex)
    {
        //...
    }
