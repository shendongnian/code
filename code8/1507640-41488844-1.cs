    public void DoWorkWithFile(IProgress<double> progress)
    {
        var lines = File.ReadAllLines("path to a file");
        for (int i = 0; i < lines.Length; i++)
        {
            // do stuff with the line
            progress.Report(100 * i / (double)lines.Length);
        }
    }
