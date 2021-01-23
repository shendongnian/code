    public class DateTimeConverter : JsonConverter<DateTime> {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            return DateTime.Parse(reader.GetString());
        }
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options) {
            string jsonDateTimeFormat = DateTime.SpecifyKind(value, DateTimeKind.Utc)
                .ToString("o", System.Globalization.CultureInfo.InvariantCulture);
            writer.WriteStringValue(jsonDateTimeFormat);
        }
    }
