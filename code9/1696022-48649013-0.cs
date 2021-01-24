    public class MyResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if(member.GetCustomAttribute<JsonPropertyAttribute>() is JsonPropertyAttribute jsonProperty)
            {
                property.PropertyName = jsonProperty.PropertyName;
            }
    
            return property;
        }
    }
