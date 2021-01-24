    public class MyCustomResultConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var formData = obj.SelectToken("fs_" + obj.SelectToken("id").Value<string>());
            formData.Parent.Replace(new JProperty("info", formData));
            existingValue = existingValue ?? new FormActionResult();
            serializer.Populate(obj.CreateReader(), existingValue);
            return existingValue;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(Result).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
    [JsonConverter(typeof(MyCustomResultConverter))]
    public class Result
    {
       public string Id {get; set;}
       public ResultInfo Info {get; set;}
    }
