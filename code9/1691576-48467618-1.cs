    var x = new List<string>();
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine().Trim();
        if (line.Contains("<FIPS>"))
        { 
            x.Add(line.Replace(Environment.NewLine, " "));  
        }
        else
        { 
            var s = String.Concat(x.Last(), line.Replace(Environment.NewLine, string.Empty), " "); 
            x[x.Count - 1] = s;
        }
    }             
     
