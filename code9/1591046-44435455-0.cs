    public class Customer
    {
        public string Name { get; set; }
    }
    public class Client
    {
        public string Name { get; set; }
    }
    public class URequest<T>
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string userName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string password { get; set; }
        [JsonIgnore]
        public IList<T> requestList { get; set; }
    }
    public class URequestConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(URequest<T>));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var objectType = value.GetType().GetGenericArguments()[0];
            URequest<T> typedValue = (URequest<T>) value;
            JObject containerObj = JObject.FromObject(value);
            containerObj.Add($"{objectType.Name.ToLower()}List", JToken.FromObject(typedValue.requestList));
            containerObj.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
