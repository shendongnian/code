    public void DoWorkWithFile(IProgress<int> progress)
    {
        var lines = File.ReadAllLines("path to a file");
        for (int i = 0; i < lines.Length; i++)
        {
            progress.Report(100 * i / lines.Length);
            // do stuff with the line
        }
    }
