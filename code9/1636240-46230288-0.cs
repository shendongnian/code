    public string _Name { get { return name; } }
    string name;
    public static Dictionary<string, string> fileName = new Dictionary<string, string>();
    public void SetFileName(string _fileName)
    {
        var isCached = fileName.TryGetValue("filename", out name);
        if (!isCached)
        {
             name = $"{_fileName}_{DateTime.Now.Ticks}";
             fileName.Add("filename", name);
        }    
    }
