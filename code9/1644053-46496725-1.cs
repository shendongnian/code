    string path = Path.Combine(Application.persistentDataPath, "data");
    path = Path.Combine(path, "test1.csv");
    
    //Create Directory if it does not exist
    if (!Directory.Exists(Path.GetDirectoryName(path)))
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
    }
    
    using (StreamWriter writer = new StreamWriter(path))
    {
        writer.WriteLine("testfile");
    }
