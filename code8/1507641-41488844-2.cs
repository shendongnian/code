    public async Task DoWorkWithFileAsync(IProgress<double> progress)
    {
        using (var reader = new StreamReader(File.OpenRead("path to a file")))
        {
            var totalLines = (double)55; // Assuming you know it
            var lineNo = 0;
            string line;
            while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                // do stuff with the line
                lineNo++;
                progress.Report(100 * lineNo / totalLines);
            }
        }
    }
