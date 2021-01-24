     public static class SerilizationExtensions
    {
        public static IContractResolver contractResolver { get; set; }
        public static string ToJson(this object obj, IContractResolver contractResolver=null)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ContractResolver =contractResolver==null? new PropertyIgnoreSerializerContractResolver():contractResolver
            });
        }
    }
    public class PropertyIncludeSerializerContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, HashSet<string>> _includedProperties;
        public PropertyIncludeSerializerContractResolver()
        {
            _includedProperties = new Dictionary<Type, HashSet<string>>();
        }
        public void IncludeProperty(Type type, params string[] jsonPropertyNames)
        {
            if (!_includedProperties.ContainsKey(type))
                _includedProperties[type] = new HashSet<string>();
            foreach (var prop in jsonPropertyNames)
                _includedProperties[type].Add(prop);
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (IsIncluded(property.DeclaringType, property.PropertyName) || property.PropertyType.IsValueType || property.PropertyType==typeof(string))
                property.ShouldSerialize = i => true;
            else
                property.ShouldSerialize = i => false;
            return property;
        }
        private bool IsIncluded(Type type, string jsonPropertyName)
        {
            if (!_includedProperties.ContainsKey(type))
                return false;
            return _includedProperties[type].Contains(jsonPropertyName);
        }
    }
