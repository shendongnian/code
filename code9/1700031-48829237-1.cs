    public void WriteRemainingLines(string line, streamReader reader)
    {
        using (var targetfile = ...)
        {
            do
            {
                targetfile.WriteLine(line);
            }
            while ((line = reader.ReadLine()) != null);
        }
    }
