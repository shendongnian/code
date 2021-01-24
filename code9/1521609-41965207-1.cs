    try
    {
      var f = await StorageFile.GetFileFromPathAsync(@"d:\temp\foo.txt");
    }
    catch (UnauthorizedAccessException ex)
    {
      Debug.WriteLine(ex.Message);
    }
    try
    {
      var localFolder = ApplicationData.Current.LocalFolder;
      var f1 = await localFolder.CreateFileAsync("foo.txt", CreationCollisionOption.ReplaceExisting);
      var f2 = await localFolder.GetFileAsync("foo.txt");
      var s1 = await f1.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.AllowOnlyReaders);
      var s2 = await f2.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.AllowOnlyReaders);
    }
    catch (IOException ex)
    {
      Debug.WriteLine(ex.Message);
    }
