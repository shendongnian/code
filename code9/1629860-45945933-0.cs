    public class IgnorePropertiesContractResolver<T> : DefaultContractResolver
    {
        private IReadOnlyList<string> ignoredProperties;
        
        public IgnorePropertiesContractResolver(params string[] properties)
        {
            ignoredProperties = properties.ToList();
        }
        
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            
            if (member.DeclaringType == typeof(T) && ignoredProperties.Contains(member.Name))
            {
                property.Ignored = true;
            }
    
            return property;
        }
    }
