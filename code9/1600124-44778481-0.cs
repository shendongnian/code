    public static string ToJson<T>(T obj, DataContractJsonSerializer serializer = null)
    {
        serializer = serializer ?? new DataContractJsonSerializer(obj == null ? typeof(T) : obj.GetType());
        using (var memory = new MemoryStream())
        {
            serializer.WriteObject(memory, obj);
            memory.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(memory))
            {
                return reader.ReadToEnd();
            }
        }
    }
