    using (var reader = new StreamReader(responseStream))
    {
        string line = reader.ReadLine();
        while(line != null)
        {
            lines.Add(line);
            line = reader.ReadLine();
        }
    }
