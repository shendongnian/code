        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var date = (DateTime)value;
            if (date.Kind == DateTimeKind.Utc)
            {
                writer.WriteValue(TimeZone.CurrentTimeZone.ToLocalTime(date));
            }
            else
            {
                writer.WriteValue(TimeZone.CurrentTimeZone.ToUniversalTime(date));
            }
        }
