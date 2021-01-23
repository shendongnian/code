    internal class PrivateResolver : DefaultContractResolver {
        protected override IList<JsonProperty> CreateProperties(
            Type type, MemberSerialization memberSerialization
        ) {
            return type
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Select(p => CreateProperty(p, memberSerialization))
                .ToList();
        }
        protected override JsonProperty CreateProperty(
            MemberInfo member, MemberSerialization memberSerialization
        ) {
            var prop = base.CreateProperty(member, memberSerialization);
            if (!prop.Writable && (member as PropertyInfo)?.GetSetMethod(true) != null) {
                prop.Writable = true;
            }
            return prop;
        }
    }
 
