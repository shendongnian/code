    static byte[] serialize<T>(T t)
    {
        var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            serializer.Serialize(ms, t);
            return ms.ToArray();            
        }
    }
    static object deserialize(byte[] bytes)
    {
        var serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        using (var ms = new MemoryStream(bytes))
            return serializer.Deserialize(ms);
    }
    [Serializable] class arrays { public decimal[] decArray; public int[] intArray; }
