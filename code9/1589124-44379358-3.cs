    public class ServicePropertyContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (property.DefaultValueHandling == null && property.PropertyType.GetServicePropertyValueType() != null)
            {
                property.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            }
            return property;
        }
    }
