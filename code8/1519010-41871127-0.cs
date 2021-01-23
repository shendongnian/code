    var fs = File.OpenText("file.xml");
    var partitions = new List<string>();
    var sb = new StringBuilder();
    string line;
    while ((line = fs.ReadLine()) != null)
    {
        if (line.StartsWith("===:") && line.EndsWith(":==="))
        {
            if(sb.Length > 0)
                partitions.Add(sb.ToString());
            continue;
        }
        sb.AppendLine(line);
    }
     if(sb.Length > 0)
        partitions.Add(sb.ToString());
