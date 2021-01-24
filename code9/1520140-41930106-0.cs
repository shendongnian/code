    string appDataDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
    string filePath = "Test/empty/abc.txt";
    string parentPath = Path.Combine(appDataDir, "Test/empty");
    string path = Path.Combine(appDataDir, filePath);
    Java.IO.File file = new Java.IO.File(path);
    Directory.CreateDirectory(parentPath);//make sure the parent directory is created
    file.CreateNewFile();//create the file
    if (file.Exists())
    {
      ...
    }
