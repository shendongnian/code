    public class GuidShortGuidConverter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return objectType == typeof(Guid);
                }
        
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                    var shortGuid = new ShortGuid(reader.Value.ToString());
                    return shortGuid.Guid;
                }
        
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    var customValue = new ShortGuid((Guid) value);
                    writer.WriteValue(customValue.ToString());
                }
            }
