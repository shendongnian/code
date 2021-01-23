    using System;
    void Start ()
    {
        string[] args = Environment.CommandLine.Split(' ');
        if (args.Length < 1)
        {
            Debug.Log("There is no file that is trying to be opened!");
            return;
        }
        string path = args[1];
        StartCoroutine(myPlayWav(path));
    }
