    SymmetricKey Key;
    DatabaseOptions options = new DatabaseOptions();
    await Task.Run(() =>
    {
        Key = new SymmetricKey(encryptionPassword);
        options.EncryptionKey = Key;
        options.Create = true;
        options.StorageType = StorageEngineTypes.SQLite;
    });
    var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).Path;
    var dir = Directory.CreateDirectory(path);
    Manager manager = new Manager(dir, Manager.DefaultOptions);
    encryptedDatabase = manager.GetDatabase(database);
