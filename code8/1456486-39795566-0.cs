    public static string GetDirectoryAsJson(string path)
    {
        return GetDirectoryAsJObject(new DirectoryInfo(path)).ToString();
    }
    public static JObject GetDirectoryAsJObject(DirectoryInfo directory)
    {
        JObject obj = new JObject();
        foreach (DirectoryInfo d in directory.EnumerateDirectories())
        {
            obj.Add(d.Name, GetDirectoryAsJObject(d));
        }
        foreach (FileInfo f in directory.GetFiles())
        {
            obj.Add(f.Name, JValue.CreateNull());
        }
        return obj;
    }
