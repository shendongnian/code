    internal static void WriteValueToStream(Object value, BinaryWriter writer)
    {
        if (known type) { ... }
        else
        {
            ...
            var formatter = new BinaryFormatter();
            if (SessionStateUtility.SerializationSurrogateSelector != null)
            {
                formatter.SurrogateSelector = SessionStateUtility.SerializationSurrogateSelector;
            }
            formatter.Serialize(writer.BaseStream, value);
        }
    }
