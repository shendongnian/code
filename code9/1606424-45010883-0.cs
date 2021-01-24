    public class BaseClass
    {
        public string BaseClassProperty { get; set; }
    }
    public class ChildClass: BaseClass
    {
        public string ChildClassProperty { get; set; }
    }
    public class CustomContractResolver : DefaultContractResolver
    {
        
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            var propsToIgnore = typeof(BaseClass).GetProperties().Select(p => p.Name).ToList();
            properties =
                properties.Where(p => !propsToIgnore.Contains( p.PropertyName) ).ToList();
            return properties;
        }
    }
