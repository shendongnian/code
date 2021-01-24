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
            JArray ja = JArray.Load(reader);
            T target = new T();
            var propsByIndex = typeof(T).GetProperties()
                .Where(p => p.CanRead && p.CanWrite && p.GetCustomAttribute<JsonArrayIndexAttribute>() != null)
                .ToDictionary(p => p.GetCustomAttribute<JsonArrayIndexAttribute>().Index);
            for (var i = 0; i < ja.Count; i++)
            {
                object value = ((JValue)ja[i]).Value;
                PropertyInfo prop;
                if (value != null && propsByIndex.TryGetValue(i, out prop))
                {
                    Type valueType = value.GetType();
                    if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(target, Convert.ToString(value));
                    }
                    else if (prop.PropertyType == typeof(int) && valueType == typeof(long))
                    {
                        prop.SetValue(target, Convert.ChangeType(value, prop.PropertyType));
                    }
                    else if (prop.PropertyType.IsAssignableFrom(valueType))
                    {
                        prop.SetValue(target, value);
                    }
                }
            }
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
