    public async Task MyMethod()
    {
        ....
        using (var writer = new StreamWriter(path)) 
        {
            writer.NewLine = "\n";
            foreach (var line in contents) 
            {
                await writer.WriteLineAsync(line);
            }
        }
        ....
    }
