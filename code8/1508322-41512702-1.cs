        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jsonObject = JObject.Load(reader);
            var configuration = (existingValue as Configuration ?? new Configuration());
            // I created the JsonConverter for those 2 properties
            configuration.c = myCustomProcessMethod(jsonObject["c"].RemoveFromLowestPossibleParent());
            configuration.obj2 = myCustomProcessMethod2(jsonObject["obj2"].RemoveFromLowestPossibleParent().ToObject<ValletConfiguration>());
            // Populate the remaining standard properties
            using (var subReader = jsonObject.CreateReader())
            {
                serializer.Populate(subReader, configuration);
            }
            return configuration;
        }
