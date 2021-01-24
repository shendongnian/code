    protected override bool OnBackButtonPressed()
    {        
        Device.BeginInvokeOnMainThread(async () =>
        {
              var action = await DisplayActionSheet(
                "ActionSheet: Send to?", "Cancel", null, "Facebook", "twitter", "Instagram");
              //your logic             
        });
        return true; //you handled the back button press
    }
