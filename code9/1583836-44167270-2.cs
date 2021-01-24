    /// <summary>
    /// Custom converter for returning a DateTime which has been stripped of any time zone information
    /// </summary>
    public class TimezonelessDateTimeConverter : DateTimeConverterBase {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException("An exercise for the reader...");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            // We'll make use of Json.NET's own IsoDateTimeConverter so 
            // we don't have to re-implement everything ourselves.
            var isoConverter = new IsoDateTimeConverter();
            // Deserialise into a DateTimeOffset which will hold the 
            // time and the timezone from the JSON.
            var withTz = (DateTimeOffset)isoConverter.ReadJson(reader, typeof(DateTimeOffset), existingValue, serializer);
            // Return the DateTime component. This will be the original 
            // datetime WITHOUT timezone information.
            return withTz.DateTime;
        }
    }
