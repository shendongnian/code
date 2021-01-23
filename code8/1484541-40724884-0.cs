    class Test {
        [JsonConverter(typeof(StrangeBoolConverter))]
        public bool EndOfDay { get; set; }
        private class StrangeBoolConverter : JsonConverter {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
                // write it as 1 or 0
                writer.WriteValue((bool) value ? 1 : 0);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
                // but when reading - expect "true" or "false"
                return Convert.ToBoolean(reader.Value);
            }
            public override bool CanConvert(Type objectType) {
                return objectType == typeof(bool);
            }
        }
    }
