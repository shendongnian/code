    public class Array3DConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (!objectType.IsArray)
                return false;
            return objectType.GetArrayRank() == 3;
        }
        object ReadJsonGeneric<T>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType == JsonToken.StartArray)
            {
                // Handle case when it's actually a 3d array in the JSON.
                var list = serializer.Deserialize<List<List<List<T>>>>(reader);
                return list.Select((l, i) => new KeyValuePair<int, List<List<T>>>(i, l)).To3DArray();
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                // Handle case when it's a dictionary of key/value pairs.
                var dictionary = serializer.Deserialize<SortedDictionary<int, List<List<T>>>>(reader);
                return dictionary.To3DArray();
            }
            else
            {
                throw new JsonSerializationException("Invalid reader.TokenType " + reader.TokenType);
            }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            try
            {
                var elementType = objectType.GetElementType();
                var method = GetType().GetMethod("ReadJsonGeneric", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                return method.MakeGenericMethod(new[] { elementType }).Invoke(this, new object[] { reader, objectType, existingValue, serializer });
            }
            catch (TargetInvocationException ex)
            {
                // Wrap the TargetInvocationException in a JsonSerializerException
                throw new JsonSerializationException("Failed to deserialize " + objectType, ex);
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static class EnumerableExtensions
    {
        public static T[,,] To3DArray<T>(this IEnumerable<KeyValuePair<int, List<List<T>>>> jaggedArray)
        {
            if (jaggedArray == null)
                throw new ArgumentNullException("jaggedArray");
            var counts = new int[3];
            foreach (var pair in jaggedArray)
            {
                var i = pair.Key;
                counts[0] = Math.Max(i + 1, counts[0]);
                if (pair.Value == null)
                    continue;
                var jCount = pair.Value.Count;
                counts[1] = Math.Max(jCount, counts[1]);
                for (int j = 0; j < jCount; j++)
                {
                    if (pair.Value[j] == null)
                        continue;
                    var kCount = pair.Value[j].Count;
                    counts[2] = Math.Max(kCount, counts[2]);
                }
            }
            var array = new T[counts[0], counts[1], counts[2]];
            foreach (var pair in jaggedArray)
            {
                var i = pair.Key;
                if (pair.Value == null)
                    continue;
                var jCount = pair.Value.Count;
                for (int j = 0; j < jCount; j++)
                {
                    if (pair.Value[j] == null)
                        continue;
                    var kCount = pair.Value[j].Count;
                    for (int k = 0; k < kCount; k++)
                        array[i, j, k] = pair.Value[j][k];
                }
            }
            return array;
        }
    }
