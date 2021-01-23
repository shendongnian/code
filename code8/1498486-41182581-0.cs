    using (StreamWriter writer = new StreamWriter(fileName, false)) // <-- this is the change
    {
        //accesses the nested lists
        foreach (var line in aQuestion)
        {
            foreach (var value in line)
            {
                writer.WriteLine(string.Join("\n", value));
            }
        }
    }
