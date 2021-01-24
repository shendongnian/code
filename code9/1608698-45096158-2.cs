    private async void Grid_Loading(FrameworkElement sender, object args)
    {
       Windows.ApplicationModel.Package package = Windows.ApplicationModel.Package.Current;
       StorageFolder installedLocation = package.InstalledLocation;
       StorageFolder targetLocation = ApplicationData.Current.LocalFolder;
            
       var targetFile = await installedLocation.GetFileAsync("Contacts.xml");
       await targetFile.MoveAsync(targetLocation);
       TARGETFILEPATH = ApplicationData.Current.LocalFolder.Path.ToString() + "\\Contacts.xml";
       loadContacts();
    }
