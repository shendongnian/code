    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var activities = await App.XivicServicesClient
                              .DataAccessCalls
                              .GetRecordsAsync<ActivityDef>(null, new ConnectionInfo(null, App.XivicServicesClient.AuthToken));
        foreach (var activityCode in activities.Select(a => a.Code))
        {
            ActivityPicker.Items.Add(activityCode);
        }
    }
    
