    void Start ()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        string path = args[0];
        StartCoroutine(myPlayWav(path));
    }
