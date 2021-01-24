    var lines = File.ReadAllLines(@"C:\1.txt").ToList();
    for (int i = 0; i < lines.Count; i++)
    {
        if (lines[i].StartsWith("PROC"))
        {
            lines.Insert(i, "NEW TEXT");
            i++;
        }
    }
