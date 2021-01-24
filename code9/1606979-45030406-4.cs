    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        object retVal;
        switch (reader.TokenType)
        {
            case JsonToken.StartObject:
                var instance = (T)serializer.Deserialize(reader, typeof(T));
                retVal = new List<T> { instance };
                break;
            case JsonToken.StartArray:
                retVal = serializer.Deserialize(reader, objectType);
                break;
            case JsonToken.String:
                retVal = ReadStringAsContentObject();
                break;
            default:
                throw new ArgumentException();
        }
        return retVal;
        object ReadStringAsContentObject()
        {
            var content = new T();
            content.Content = reader.ReadAsString();
            var returnObject = new List<T> { content };
            return returnObject;
        }
    }
