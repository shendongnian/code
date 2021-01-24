    class LocaleDictionaryConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary<Locale, string>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Dictionary<Locale, string> dict = new Dictionary<Locale, string>();
            foreach (var prop in obj.Properties())
            {
                dict.Add(Locale.FromAbbreviation(prop.Name), (string)prop.Value);
            }
            return dict;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            IDictionary<Locale, string> dict = (IDictionary<Locale, string>)value;
            JObject obj = new JObject();
            foreach (var kvp in dict)
            {
                obj.Add(kvp.Key.Abbreviation, kvp.Value);
            }
            obj.WriteTo(writer);
        }
    }
