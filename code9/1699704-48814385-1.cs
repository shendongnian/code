    DateTime start = DateTime.Now;
    var chartData = File.ReadLines(file)
        .Where(line => !string.IsNullOrWhiteSpace(line))
        .Select( line => line.Split(':') )
        .Select( parts => new { x = start.AddMinutes(int.Parse(parts[0]) * 15), y = int.Parse(parts[1]) } )
        .ToArray();
