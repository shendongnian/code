    try
    {
      var f = File.OpenRead(@"d:\temp\foo.txt");
    }
    catch (UnauthorizedAccessException ex)
    {
      Debug.WriteLine(ex.Message);
    }
    
    try
    {
      var localPath = ApplicationData.Current.LocalFolder.Path;
      var filename = Path.Combine(localPath, "foo.txt");
      var f1 = File.OpenWrite(filename);
      var f2 = File.OpenRead(filename);
    }
    catch (IOException ex)
    {
      Debug.WriteLine(ex.Message);
    }
