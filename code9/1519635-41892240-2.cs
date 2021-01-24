    string[] lines = System.IO.File.ReadAllLines("file.txt");
    string result = "";
    for(int i=0;i<lines.Length;i++)
    {
        MatchCollection mc = Regex.Matches(lines[i], "D;");
        result+= string.Format("{0} - {1}\r\n", i+1, mc.Count);
    }
