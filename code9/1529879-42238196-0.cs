    public T GetFromFile<T>(string path, IStreamDeserializer<T> deserializer)
    {
        using (var stream = GetFileStream(path))
        {
            return deserializer.Read(stream);
        }
    }
