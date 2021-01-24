    public static DataSet LoadDataSet()
    {
        var asm = typeof(Program).Assembly;
    
        string filePath = Path.GetDirectoryName(asm.CodeBase).ToLowerInvariant().Replace(@"file:\", "");
        filePath = Path.Combine(filePath, "data.json");
        string jsonText = null;
        if (!File.Exists(filePath))
        {
            using (var stream = asm.GetManifestResourceStream($"{asm.GetName().Name}.data.json"))
            {
                using (var fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
                {
                    stream.CopyTo(fs);
                }
            }
        }
        else
            jsonText = File.ReadAllText(filePath);
    
        DataSet dataSet = JsonConvert.DeserializeObject<DataSet>(jsonText);
        return dataSet;
    }
    
    public static void SaveDataSet(DataSet dataSet)
    {
        var asm = typeof(Program).Assembly;
        string filePath = Path.GetDirectoryName(asm.CodeBase).ToLowerInvariant().Replace(@"file:\", "");
        filePath = Path.Combine(filePath, "data.json");
    
        string jsonText = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
        File.WriteAllText(filePath, jsonText);
    }
