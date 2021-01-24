    /// <summary>
    /// Custom converter for returning a DateTime which has been stripped of any time zone information
    /// </summary>
    public class TimezonelessDateTimeConverter : DateTimeConverterBase {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException("An exercise for the reader...");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var isoConverter = new IsoDateTimeConverter();
            var withTz = (DateTimeOffset)isoConverter.ReadJson(reader, typeof(DateTimeOffset), existingValue, serializer);
            return withTz.DateTime;
        }
    }
