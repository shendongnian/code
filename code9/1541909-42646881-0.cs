    void Start() 
    {
        dir = new DirectoryInfo(@folder);
        info = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
        arrLength = info.Length;
        // Starting in 0.1 seconds.
        // and will be launched every 5 seconds
        InvokeRepeating("medialogic", 0.1f, 5f);
    }
