    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
         if(reader.ValueType.FullName == typeof(string).FullName)
        {
            string str = (string)reader.Value;
            if (str == null || !str.StartsWith("0x"))
                throw new JsonSerializationException();
            return Convert.ToUInt32(str.Substring("0x".Length), 16);
        }
        else
            throw new JsonSerializationException();
    }
