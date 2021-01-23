    public class JsonIncludeContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
    
            var actualProperties = type.GetProperties();
    
            foreach (var jsonProperty in properties)
            {
                // Check if it got our JsonInclude attribute.
                var property = actualProperties.FirstOrDefault(x => x.Name == jsonProperty.PropertyName);
                if (property != null && property.GetCustomAttribute(typeof(JsonInclude)) != null)
                {
                    jsonProperty.Ignored = false;
                }
            }
            return properties;
        }
    }
    
    [DataContract]
    public class Place
    {
        [JsonInclude] // Will override JsonIgnore.
        [JsonIgnore]
        [DataMember(EmitDefaultValue = false)]
        public int PlaceId { get; set; }
    
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string PlaceName { get; set; }
    }
    
    public class JsonInclude : Attribute
    {
        
    }
