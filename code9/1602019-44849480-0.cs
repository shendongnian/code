    [JsonConverter(typeof(CharArraySerializer))]
            public class CharArray : List<char>
            {
                public string Key { get; }
    
                public CharArray(string key)
                {
                    Key = key;
                }
    
                public CharArray(string key,List<char> list):base(list)
                {
                    Key = key;
                }
            }
    
            public class CharArraySerializer : JsonConverter
            {
                public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
                {
                    var array = value as CharArray;
    
                    writer.WriteStartObject();
                    writer.WritePropertyName("key");
                    writer.WriteValue(array.Key);
    
                    writer.WritePropertyName("data");
                    serializer.Serialize(writer, array.ToArray());
    
                    writer.WriteEndObject();
                }
    
                public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
                {
                     var jsonObject = JObject.Load(reader);   
    
                     var key = jsonObject.Value<string>("key");
    
                     var array = jsonObject.Value<JArray>("data").Select(t=>t.Value<char>()).ToList();
    
                     return new CharArray(key,array);
                }
    
                public override bool CanConvert(Type objectType)
                {
                    return typeof(CharArray).IsAssignableFrom(objectType);
                }
            }
