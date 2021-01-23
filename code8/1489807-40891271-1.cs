    public class VectorSerializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var token = JToken.FromObject(value);
            var x = token["X"].Value<float>();
            var y = token["Y"].Value<float>();
            var z = token["Z"].Value<float>();
            var vector = new[] { x, y, z };
            var o = JArray.FromObject(vector);
            o.WriteTo(writer);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var item = JObject.Load(reader);
            var vector = item["myVector3"].ToObject<float[]>();
            return new myVector3 { X = vector[0], Y = vector[1], Z = vector[2] };
        }
    
        public override bool CanConvert(Type objectType)
        {
            return typeof(myVector3).IsAssignableFrom(objectType);
        }
    }
    public class myVector3
    {
        public float X, Y, Z;
    }
