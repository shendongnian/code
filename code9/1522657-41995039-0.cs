    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var activityCodes = await Task.Factory.StartNew(async () => { await Initialise(); });
        foreach (var activityCode in activityCodes)
        {
            ActivityPicker.Items.Add(activityCode);
        }
    }
    
    private async Task<List<string>> Initialise()
    {
        var activities = await App.XivicServicesClient
                           .DataAccessCalls
                           .GetRecordsAsync<ActivityDef>(null, new ConnectionInfo(null, App.XivicServicesClient.AuthToken));
    
        return activities.Select(a => a.Code).ToList();
    }
