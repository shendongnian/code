    Dictionary<string, string> arIdToArTypeMapping = new Dictionary<string, string>();
    
    using (var sr = File.OpenText("test.csv"))
    {
        var csvConfiguration = new CsvConfiguration
        {
            SkipEmptyRecords = true
        };
    
        using (var csvReader = new CsvReader(sr, csvConfiguration))
        {
            while (csvReader.Read())
            {
                string arId = csvReader.GetField("AR ID");
                string arType = csvReader.GetField("AR Type");
    
                if (!string.IsNullOrEmpty(arId) && !string.IsNullOrEmpty(arType))
                {
                    arIdToArTypeMapping.Add(arId, arType);
                }
            }
        }
    }
