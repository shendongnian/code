    using (StreamWriter writer = new StreamWriter(File.OpenWrite(filePath)))
    {
        foreach(List<string> lines in _output)
        {
            foreach(string line in lines)
            {
                writer.WriteLine(line);
            }
            writer.WriteLine(line);
        }
    }
