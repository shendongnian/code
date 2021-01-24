    public abstract class SerializableObject<T>
    {    
        public static T FromJObject(JObject jObject) => 
             Parse($"{jObject}");
        public static T Parse(string json) =>
            JsonConvert.DeserializeObject<T>(json, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
        public JObject ToJObject() => JObject.Parse(ToJson());
        public string ToJson() =>
            JsonConvert.SerializeObject(this, Formatting.Indented, 
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects
                });
    }
