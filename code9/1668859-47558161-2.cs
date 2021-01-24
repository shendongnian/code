    public class JsonArrayIndexAttribute : Attribute
    {
        public int Index { get; private set; }
        public JsonArrayIndexAttribute(int index)
        {
            Index = index;
        }
    }
    public class ArrayToObjectConverter<T> : JsonConverter where T : class, new()
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            var propsByIndex = typeof(T).GetProperties()
                .Where(p => p.CanRead && p.CanWrite && p.GetCustomAttribute<JsonArrayIndexAttribute>() != null)
                .ToDictionary(p => p.GetCustomAttribute<JsonArrayIndexAttribute>().Index);
            JObject obj = new JObject(array
                .Select((jt, i) =>
                {
                    PropertyInfo prop;
                    return propsByIndex.TryGetValue(i, out prop) ? new JProperty(prop.Name, jt) : null;
                })
                .Where(jp => jp != null)
            );
            T target = new T();
            serializer.Populate(obj.CreateReader(), target);
            return target;
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
