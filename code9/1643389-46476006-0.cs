    public class RsaConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RSAParameters);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var param = new RSAParameters();
            param.D = Convert.FromBase64String((string)obj["D"]);
            // other properties...
            return param;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var obj = (JObject)JToken.FromObject(value);
            RSAParameters param = (RSAParameters)value;
            if (obj["D"] == null && param.D != null) obj.Add("D", Convert.ToBase64String(param.D));
            // other properties...
            obj.WriteTo(writer);
        }
    }
