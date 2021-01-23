    using System;
    void Start ()
    {
        string[] args = Environment.CommandLine.Split(' ');
        string path = args[1];
        StartCoroutine(myPlayWav(path));
    }
