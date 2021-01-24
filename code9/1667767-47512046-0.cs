    public class AClassConverter : JsonConverter
    {
        private readonly Type[] _types;
        public AClassConverter(params Type[] types)
        {
            _types = types;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jObj = JObject.Load(reader);
            var classType = (ClassType)jObj["ClassType"].CreateReader().ReadAsInt32();
            return classType == ClassType.B ? 
                (A)jObj.ToObject<B>() : 
                (A)jObj.ToObject<C>();
        }
        public override bool CanRead => true;
        public override bool CanWrite => false;
        public override bool CanConvert(Type objectType)
        {
            return _types.Any(t => t == objectType);
        }
    }
