    public class CustomJavaScriptDateTimeConverter : JavaScriptDateTimeConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var js = new JsonSerializer() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat };
            js.Serialize(writer, value);
        }
    }
