    public class MyContractResolver : DefaultContractResolver
    {
        public new static readonly MyContractResolver Instance = new MyContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
    
            if (property.DeclaringType == typeof(RealmObject))
            {
                property.ShouldSerialize = o => false;
            }
    
            return property;
        }
    }
