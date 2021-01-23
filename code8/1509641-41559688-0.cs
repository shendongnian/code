    public class ListToDictionaryConverter<T> : JsonConverter where T : class
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<T>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var list = existingValue as List<T> ?? (List<T>)serializer.ContractResolver.ResolveContract(objectType).DefaultCreator();
            if (reader.TokenType == JsonToken.StartArray)
                serializer.Populate(reader, list);
            else if (reader.TokenType == JsonToken.StartObject)
            {
                var dict = serializer.Deserialize<Dictionary<int, T>>(reader);
                foreach (var pair in dict)
                    list.SetOrAddAt(pair.Key, pair.Value, default(T));
            }
            else
            {
                throw new JsonSerializationException(string.Format("Invalid token {0}", reader.TokenType));
            }
            return list;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = (IList<T>)value;
            writer.WriteStartObject();
            for (int i = 0; i < list.Count; i++)
            {
                // Omit null values.
                if (list[i] == default(T))
                    continue;
                writer.WritePropertyName(((JValue)i).ToString());
                serializer.Serialize(writer, list[i]);
            }
            writer.WriteEndObject();
        }
    }
    public static class ListExtensions
    {
        public static void SetOrAddAt<T>(this IList<T> list, int index, T value, T defaultValue = default(T))
        {
            if (list == null)
                throw new ArgumentNullException("list");
            list.EnsureCount(index + 1, defaultValue);
            list[index] = value;
        }
        public static void EnsureCount<T>(this IList<T> list, int count, T defaultValue = default(T))
        {
            if (list == null)
                throw new ArgumentNullException("list");
            int oldCount = list.Count;
            if (count > oldCount)
            {
                for (int i = oldCount; i < count; i++)
                    list.Add(defaultValue);
            }
        }
    }
