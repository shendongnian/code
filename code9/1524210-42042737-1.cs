    line = reader.ReadLine();
    while (line != null)
    {
        string[] words = JsonSplitString(line);
        string json = words[1];
        writer.WriteLine("{0}", json);
        line = reader.ReadLine();
    }
