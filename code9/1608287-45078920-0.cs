    public static void WriteSymbol(Stream stream, Symbol symbol)
    {
        using (var streamWriter = new StreamWriter(stream))
        {
            JsonSerializer.Create(SerializerSettings).Serialize(streamWriter, symbol); 
            // test stream here               
        }
    }
