    public class CustomerContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (typeof(Order).IsAssignableFrom(property.DeclaringType) && property.PropertyName.Equals(nameof(Order.Customer)))
            {
                property.ShouldSerialize = instance => { return false; };
            }
            return property;
        }
    }
