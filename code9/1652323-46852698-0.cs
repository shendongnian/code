        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Type type = value.GetType();
            IEnumerable keys = (IEnumerable)type.GetProperty("Keys").GetValue(value, null);
            IEnumerable values = (IEnumerable)type.GetProperty("Values").GetValue(value, null);
            IEnumerator valueEnumerator = values.GetEnumerator();
            writer.WriteStartObject();
            foreach (object key in keys)
            {
                valueEnumerator.MoveNext();
                writer.WritePropertyName(JsonConvert.SerializeObject(key));
                serializer.Serialize(writer, valueEnumerator.Current);
            }
            writer.WriteEndObject();
        }
