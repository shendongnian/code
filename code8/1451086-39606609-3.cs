    var lines = File.ReadAllLines(Fullpath);
    File.WriteAllLines(Fullpath, lines.Take(lines.Length - 1).ToArray());
    DisplayData(MessageType.Incoming, lines[lines.Length - 1]);
    
    var text = new StringBuilder();
    var data = File.ReadAllLines(Fullpath);
    var lines = data.Take(data.Count() - 2);
    var last = lines.Last();
    foreach (string s in lines)
    {
        if(s.Equals(last))
        {
            text.AppendLine(s.Replace("OK", "NG"));
        }
        else
        {
            text.AppendLine(s);
        }
    }
    
    using (var file = new StreamWriter(File.Create(Fullpath)))
    {
        file.Write(text.ToString());
    }
