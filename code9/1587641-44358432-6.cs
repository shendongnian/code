    public class DbCommandSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dbCommand = value as DbCommand;
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Query");
            writer.WriteValue(dbCommand.CommandText);
            writer.WritePropertyName("Parameters");
            writer.WriteStartObject();
            foreach (DbParameter param in dbCommand.Parameters)
            {
                writer.WritePropertyName(param.ParameterName);
                writer.WriteValue(param.Value);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.Flush();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(DbCommand).IsAssignableFrom(objectType);
        }
    }
