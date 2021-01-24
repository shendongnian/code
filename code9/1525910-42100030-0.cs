    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
    
            if (property.DeclaringType == typeof(Foo) && property.PropertyName == "Bar")
            {
                property.ShouldSerialize = instance => false;
            }
    
            return property;
        }
    }
