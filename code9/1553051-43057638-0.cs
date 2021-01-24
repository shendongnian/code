        public class ReferenceConverter<T> : JsonConverter
        {
            private Dictionary<string, T> ReferenceDict { get; set; }
            public ReferenceConverter(Dictionary<string, T> referenceDict)
            {
                ReferenceDict = referenceDict;
            }
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(T);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JArray array = JArray.Load(reader);
                if (array.Count == 2 && 
                    array[0].Type == JTokenType.String && 
                    (string)array[0] == "FOO" && 
                    array[1].Type == JTokenType.String)
                {
                    string key = (string)array[1];
                    T obj;
                    if (ReferenceDict.TryGetValue(key, out obj))
                        return obj;
                    throw new JsonSerializationException("No " + typeof(T).Name + " was found with the key \"" + key + "\".");
                }
                throw new JsonSerializationException("Reference had an invalid format: " + array.ToString());
            }
            public override bool CanWrite
            {
                get { return false; }
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
