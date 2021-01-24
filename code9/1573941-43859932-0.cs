    excelPath = Path.Combine(currentDir, "MyFile.csv");
    string[] lines = File.ReadAllLines(excelPath);
    List<string[]> values = new List<string[]>();
    foreach (string line in lines)
    {
        values.Add(line.Split(';'));
    }
    // parse strings into int, double, date, etc.
