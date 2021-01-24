    public class JsonDataObjectConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDataObject).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JsonObject jsonObject = (JsonObject)value;
            if (jsonObject.DataObject.GetType() == typeof(MyDataObject))
            {
                MyDataObject dataObject = (MyDataObject) jsonObject.DataObject;
                
                writer.WriteStartObject();
                writer.WritePropertyName("id");
                writer.WriteValue(dataObject.Id);
                writer.WritePropertyName("name");
                writer.WriteValue(dataObject.Name);
                writer.WriteEndObject();
            }
        }
    }
