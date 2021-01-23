    public class DeclaredFieldJsonConverter<T> : JsonConverter where T: new()
    {
        const string basePropertyName = "base";
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jObj = JObject.Load(reader);
            existingValue = existingValue ?? new T();
            var type = existingValue.GetType();
            while (jObj != null && type != null)
            {
                var basejObj = jObj.ExtractPropertyValue(basePropertyName) as JObject;
                JsonObjectContract contract = (JsonObjectContract)DeclaredFieldContractResolver.Instance.ResolveContract(type);
                foreach (var jProperty in jObj.Properties())
                {
                    var property = contract.Properties.GetClosestMatchProperty(jProperty.Name);
                    if (property == null)
                        continue;
                    var value = jProperty.Value.ToObject(property.PropertyType, serializer);
                    property.ValueProvider.SetValue(existingValue, value);
                }
                type = type.BaseType;
                jObj = basejObj;
            }
            return existingValue;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            WriteJson(writer, value, value.GetType(), serializer);
        }
        void WriteJson(JsonWriter writer, object value, Type type, JsonSerializer serializer)
        {
            JsonObjectContract contract = (JsonObjectContract)DeclaredFieldContractResolver.Instance.ResolveContract(type);
            writer.WriteStartObject();
            foreach (var property in contract.Properties.Where(p => !p.Ignored))
            {
                writer.WritePropertyName(property.PropertyName);
                serializer.Serialize(writer, property.ValueProvider.GetValue(value));
            }
            var baseType = type.BaseType;
            if (baseType != null && baseType != typeof(object))
            {
                writer.WritePropertyName(basePropertyName);
                WriteJson(writer, value, baseType, serializer);
            }
            writer.WriteEndObject();
        }
    }
    public static class JsonExtensions
    {
        public static JToken ExtractPropertyValue(this JObject obj, string name)
        {
            if (obj == null)
                return null;
            var property = obj.Property(name);
            if (property == null)
                return null;
            var value = property.Value;
            property.Remove();
            property.Value = null;
            return value;
        }
    }
    class DeclaredFieldContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
        // See also https://stackoverflow.com/questions/33557737/does-json-net-cache-types-serialization-information
        static DeclaredFieldContractResolver instance;
        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static DeclaredFieldContractResolver() { instance = new DeclaredFieldContractResolver(); }
        public static DeclaredFieldContractResolver Instance { get { return instance; } }
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var fields = objectType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(f => !f.IsNotSerialized);
            return fields.Cast<MemberInfo>().ToList();
        }
        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            var contract = base.CreateObjectContract(objectType);
            contract.MemberSerialization = MemberSerialization.Fields;
            return contract;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return base.CreateProperties(type, MemberSerialization.Fields);
        }
    }
