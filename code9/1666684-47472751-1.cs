    foreach (var fileName in fileFastPath)
    {
        var start = DateTimeOffset.UtcNow;
        var allLines = File.ReadAllLines(fileName);
 
        foreach (var line in allLines.Where(line => line.Contains("Acquisition depuis")))
        {
            DateTimeOffset.TryParse(line.Split('\t')[1], out start);
        }
    
        double x = 0, y = 0, z = 0;
    
        var lineValues = from line in allLines
                         where !line.Contains("Acquisition depuis")
                         select line.Split('\t') into values
                         where double.TryParse(values[3], out x)
                         where double.TryParse(values[4], out y)
                         where double.TryParse(values[5], out z)
                         let milliseconds = double.Parse(values[0])
                         select (x, y, z, milliseconds);
        foreach (var (sp1, sp2, vear, milliseconds) in lineValues)
        {
            var updatedStart = start + TimeSpan.FromMilliseconds(milliseconds);
            var existingValue = Data
                .Select($"Time = #{updatedStart: yyyy-MM-dd HH:mm:ss.fff}#")
                .FirstOrDefault(existing => existing != null);
    
            if (existingValue != null)
            {
                existingValue["SP1 Bar"] = sp1;
                existingValue["SP2 Bar"] = sp2;
                existingValue["VEAR_POS %"] = vear;
            }
        }
    }
