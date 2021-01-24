    class IgnoreGuidsResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (prop.PropertyType == typeof(Guid))
            {
                prop.Ignored = true;
            }
            return prop;
        }
    }
