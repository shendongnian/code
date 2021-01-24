    public static Dictionary<string, object> ByteToObjectArray(byte[][] bytes)
    {
        var dict = new Dictionary<string, object>();
        var formatter = new BinaryFormatter();
        for (int i = 0; i < bytes.Length; i += 2)
        {
            string key = Encoding.UTF8.GetString(bytes[i]);
            // Alternatively
            //string key = Encoding.Unicode.GetString(bytes[i]);
            using (var stream = new MemoryStream(bytes[i + 1]))
            {
                object obj = formatter.Deserialize(stream);
                dict.Add(key, obj);
            }
        }
        return dict;
    }
