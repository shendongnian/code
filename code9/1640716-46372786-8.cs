        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.Integer:
                    // Input was already an integer.  Return it
                    return (int)JToken.Load(reader);
                case JsonToken.String:
                    {
                        int num;
                        if (Int32.TryParse(reader.Value.ToString(), NumberStyles.Integer, NumberFormatInfo.InvariantInfo, out num))
                            return num;
                        else
                            return 0;
                    }
                default:
                    throw new JsonSerializationException(string.Format("Unexpected token {0} at path {1}", reader.TokenType, reader.Path));
            }
    Or, if you prefer to consume and discard the unexpected data without throwing an exception (I don't recommend this) you could use [`JsonReader,Skip()`](https://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_JsonReader_Skip.htm):
                default:
                    Debug.WriteLine(string.Format("Unexpected token {0} at path {1}", reader.TokenType, reader.Path));
                    reader.Skip();
                    return 0;
