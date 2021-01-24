    Chilkat.Zip zip = new Chilkat.Zip();
    bool success;
    Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.TemporaryFolder;
    string a = localFolder.Path + "\\sample.zip";
    success = zip.NewZip(a);
    if (success != true)
    {
        Debug.WriteLine(zip.LastErrorText);
        return;
    }
    zip.SetPassword("secret");
    zip.PasswordProtect = true;
    bool saveExtraPath;
    saveExtraPath = false;
    StorageFolder appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
    StorageFolder assets = await appInstalledFolder.GetFolderAsync("Assets");
    string filePath = assets.Path + "\\rainier.jpg";
    success = await zip.AppendOneFileOrDirAsync(filePath, saveExtraPath);
    bool success2 = await zip.WriteZipAndCloseAsync();
    if (success != true)
    {
        Debug.WriteLine(zip.LastErrorText);
        return;
    }
    Debug.WriteLine("Zip Created!");
