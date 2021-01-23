    public class IgnoreSpecifiedContractResolver : DefaultContractResolver
    {
        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."
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
