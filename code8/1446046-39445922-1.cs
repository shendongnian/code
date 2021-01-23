    string[] args = System.Environment.CommandLineArgs();
    string path = args[0];
    if (args.Length == 0)
    {
        Debug.Log("There is no file that is trying to be opened!");
        return;
    }
    StartCoroutine(myPlayWav(path));
