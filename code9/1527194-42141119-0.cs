    List<string> lines = new List<string>();
    string line = string.Empty;
    foreach(char c in str)
    {
        if((char.ToLower(c) >= 'a' && char.ToLower(c) <= 'z') || c == 0x20)
            line += c;
        else if(c == '.')
        {
            lines.Add(line.Trim());
            line = string.Empty;
        }
    }
