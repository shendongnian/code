    public static string DataJsonSerializer<T>(T obj)
    {
        var json = string.Empty;
        var JsonSerializer = new DataContractJsonSerializer(typeof(T));
        using (var mStrm = new MemoryStream())
        {
            JsonSerializer.WriteObject(mStrm, obj);
            mStrm.Position = 0;
            using (var sr = new StreamReader(mStrm))
                json = sr.ReadToEnd();
        }
        return json;
    }
