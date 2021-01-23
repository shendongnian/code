    static object[] testData()
    {
        var reader = new StreamReader(File.OpenRead(@"TestCases.csv"));
        List<object[]> rows = new List<object[]>();
    
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            rows.Add(values);
        }
    
        return rows.ToArray<object[]>();                        
    }
