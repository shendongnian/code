    using (StreamReader reader =  process.StandardOutput)
    {
        var lines = new List<string>();
        string line;
        while ((line = reader.ReadLine()) != null)
            lines.Add(line);
        Console.Write(lines[8]);
        MessageBox.Show(lines[8]);
    }
