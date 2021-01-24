    public static List<ColList> GetData(string filePath)
    {
        var data = new List<ColList>();
        if (filePath == null || !File.Exists(filePath)) return data;
        var fileLines = File.ReadAllLines(filePath).Where(line => !string.IsNullOrEmpty(line));
        foreach (var fileLine in fileLines)
        {
            var lineParts = fileLine.Split(',');
            int tmp;
            data.Add(new ColList()
            {
                Date = lineParts[0],
                Id = lineParts.Length > 0 ? lineParts[1] : "",
                BId = lineParts.Length > 1 && int.TryParse(lineParts[2], out tmp) ? tmp : 0,
                Time = lineParts.Length > 2 && int.TryParse(lineParts[3], out tmp) ? tmp : 0,
                Talk = lineParts.Length > 3 && int.TryParse(lineParts[4], out tmp) ? tmp : 0,
                Status = lineParts.Length > 4 ? lineParts[5] : ""
            });
        }
        return data;
    }
