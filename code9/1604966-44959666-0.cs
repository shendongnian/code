    // This class overrides conversion for DateTime values
    public class MyDateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Your algorithm here
            var customValue = ((DateTime)value).Ticks;
            writer.WriteValue(customValue);
        }
    }
    // This formatter will create serializers with the above converter injected
    public class MyJsonFormatter : JsonMediaTypeFormatter
    {
        public override JsonSerializer CreateJsonSerializer()
        {
            var serializer = base.CreateJsonSerializer();
            serializer.Converters.Add(new MyDateConverter());
            return serializer;
        }
    }
    // Inside your WebApi config code, replace the default formatter with your custom one
    var defaultJsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
    config.Formatters.Remove(defaultJsonFormatter);
    config.Formatters.Insert(0, new MyJsonFormatter());
