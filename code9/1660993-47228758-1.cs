    string token = "picturesTokenNaME";
    private async void btnCreate_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            await CreatePictureFolderAsync();
            var folder = await StorageApplicationPermissions.FutureAccessList.GetFolderAsync(token);
            var file = await folder.CreateFileAsync("abc.txt", CreationCollisionOption.GenerateUniqueName);
            await FileIO.WriteTextAsync(file, "ameeeeeeeeeeeeeeeeeeeeeeeee");
        }
        catch (Exception ex) { ex.Exception("btnCreate_Click"); }
    }
