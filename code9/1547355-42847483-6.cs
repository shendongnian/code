    public class JsonDeserializationPropertyMatchConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsClass;
        }
    
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var constructor = objectType.GetConstructor(new Type[0]);
            if (constructor == null)
                throw new JsonSerializationException("A parameterless constructor is expected.");
    
            var value = constructor.Invoke(null);
    
            var jsonObject = JObject.Load(reader);
            var jsonObjectProperties = jsonObject.Properties();
    
            PropertyInfo[] typeProperties = objectType.GetProperties();
            var typePropertyTuples = new List<Tuple<PropertyInfo, Func<JProperty, bool>>>();
            foreach (var property in typeProperties.Where(x => x.CanWrite))
            {
                var attribute = property.GetCustomAttribute<JsonDeserializationPropertyMatchAttribute>(true);
                if (attribute != null)
                    typePropertyTuples.Add(new Tuple<PropertyInfo, Func<JProperty, bool>>(property, attribute.IsMatch));
                else
                    typePropertyTuples.Add(new Tuple<PropertyInfo, Func<JProperty, bool>>(property, (x) => false));
            }
                    
            foreach (JProperty jsonProperty in jsonObject.Properties())
            {
                var propertyTuple = typePropertyTuples.FirstOrDefault(x => String.Equals(jsonProperty.Name, x.Item1.Name, StringComparison.InvariantCultureIgnoreCase) || x.Item2(jsonProperty));
                if (propertyTuple != null)
                    propertyTuple.Item1.SetValue(value, jsonProperty.Value.ToObject(propertyTuple.Item1.PropertyType, serializer));
            }
    
            return value;
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
