    using (var writer = new StreamWriter(path)) 
    {
        writer.NewLine = "\n";
        foreach (var line in contents) 
        {
            writer.WriteLine(line );
        }
    }
