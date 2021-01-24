    var driveItems = await graphClient.Me.Drive.Root.ItemWithPath("Notebooks").Children.Request().GetAsync();
    
    foreach (var item in driveItems)
    {
        // Let's download the first file we get in the response.
        if (item.Package.Type == "oneNote")
        {
            // Fail 404, response body error is UnknownError.
            var driveItemContent = await graphClient.Me.Drive.Items[item.Id].Content.Request().GetAsync();
            return;
        }
    }
