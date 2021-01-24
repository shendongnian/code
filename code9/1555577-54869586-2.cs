    public class FlagConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, Object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            JObject jobject = JObject.FromObject(token);
            F result = 0;
            foreach (F f in Enum.GetValues(typeof(F)))
            {
                if (jobject[f.ToString()] != null && (bool)jobject[f.ToString()])
                {
                    result |= f; // key is present and value is true ==> set flag
                }
            }
            return result;
        }
        public override void WriteJson(JsonWriter writer, Object value, JsonSerializer serializer)
        {
            JObject result = new JObject();
            F f = (F)value;
            foreach (F f in Enum.GetValues(typeof(F)))
            {
                result[f.ToString()] = status.HasFlag(f);
            }
            writer.WriteRawValue(JsonConvert.SerializeObject(result));
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
