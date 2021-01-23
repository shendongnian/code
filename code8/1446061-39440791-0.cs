    public class CustomContractResolver : DefaultContractResolver
    {
        public static readonly CustomContractResolver Instance = new CustomContractResolver();
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => p != null).ToList();
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.Writable || member.GetCustomAttribute<JsonPropertyAttribute>() != null) return property;
            return null;
        }
    }
