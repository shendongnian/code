    public class StringToResponseConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object retVal = new Object();
            if (reader.TokenType == JsonToken.StartObject)
            {
                T instance = (T)serializer.Deserialize(reader, typeof(Response));
                retVal = instance;
            }
            else if (reader.TokenType == JsonToken.String)
            {
                string message = (string)serializer.Deserialize(reader);
                retVal = new Response { Message = message };
            }
            return retVal;
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
 
