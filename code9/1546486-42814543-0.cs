    public async Task WriteTextToFile(string file, List<string> lines, bool append)
    {
        if (!append && File.Exists(file))
            File.Delete(file);
    
        using (var writer = File.OpenWrite(file))
        {
            using (var streamWriter = new StreamWriter(writer))
                foreach (var line in lines)
                    await streamWriter.WriteLineAsync(line);
        }
    }
