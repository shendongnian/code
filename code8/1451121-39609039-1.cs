    public class RespConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Resp);
        }
        
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }
  
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var resp = (Resp)value;
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteValue(resp.ID);
            writer.WritePropertyName("site");
            writer.WriteValue(resp.Site.Trim());
            writer.WritePropertyName("pressureReading");
            writer.WriteValue(resp.PressureReading.Trim());
            writer.WritePropertyName("pressureTrend");
            writer.WriteValue(resp.PressureTrend);
            writer.WriteEndObject();
        }
      
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // the default deserialization works fine, 
            // but otherwise we'd handle that here
            throw new NotImplementedException();
        }
     }
