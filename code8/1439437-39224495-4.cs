    public class IgnoreSpecifiedContractResolver : DefaultContractResolver
    {
        static IgnoreSpecifiedContractResolver instance;
        static IgnoreSpecifiedContractResolver() { instance = new IgnoreSpecifiedContractResolver(); }
        public static IgnoreSpecifiedContractResolver Instance { get { return instance; } }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.GetIsSpecified = null;
            property.SetIsSpecified = null;
            return property;
        }
    }
