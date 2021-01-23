    using System;
    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    public class OmitTypeNamesOnDynamicsResolver : DefaultContractResolver
    {
        public static OmitTypeNamesOnDynamicsResolver Instance = new OmitTypeNamesOnDynamicsResolver();
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);
            if (member.GetCustomAttribute<System.Runtime.CompilerServices.DynamicAttribute>() != null)
            {
                prop.TypeNameHandling = TypeNameHandling.None;
            }
            return prop;
        }
    }
