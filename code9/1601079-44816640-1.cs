    string[] lines = File.ReadAllLines("a.txt");
    for(int i = 0; i<lines.Length; i++)
    {
        if(lines[i].Contains("InfoBrother"))
        {
            lines[i] = lines[i].Insert(4, "-");
        }
    }
    File.WriteAllLines("a.txt", lines);
