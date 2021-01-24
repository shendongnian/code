    public static DataSet LoadData()
    {
        var asm = typeof(Program).Assembly;
        var jsonText = "";
        using(var stream = asm.GetManifestResourceStream($"{asm.GetName().Name}.data.json"))
        {
            using (var reader = new StreamReader(stream))
            {
                jsonText = reader.ReadToEnd();
            }
        }
        DataSet dataSet = null;
        try
        {
            dataSet = JsonConvert.DeserializeObject<DataSet>(jsonText);
        }
        catch
        {
        }
        return dataSet;
    }
