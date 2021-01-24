     var dialog = new Windows.UI.Popups.MessageDialog(
                    "Check your connection and try again." ,
                    "No wifi connection");
     
        dialog.Commands.Add(new Windows.UI.Popups.UICommand("Ok") { Id = 0 });
       // add another button if you want to
       //dialog.Commands.Add(new Windows.UI.Popups.UICommand("Cancel") { Id = 1 });
        
        // example: check mobile and add another button
        if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile") 
        {
            // Adding a 3rd command will crash the app when running on Mobile !!!
            //dialog.Commands.Add(new Windows.UI.Popups.UICommand("Maybe later") { Id = 2 });
        }
     
        dialog.DefaultCommandIndex = 0;
        //dialog.CancelCommandIndex = 1;
     
        var result = await dialog.ShowAsync();
