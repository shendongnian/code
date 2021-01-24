    using System.Reflection;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    namespace WebApplication1.Controllers
    {
        internal class IgnorePropertyExceptionsResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProperty = base.CreateProperty(member, memberSerialization);
                jsonProperty.ShouldSerialize = instance => {
                    try
                    {
                        var instanceProperty = (PropertyInfo) member;
                        if (instanceProperty.CanRead)
                        {
                            instanceProperty.GetValue(instance, null);
                            return true;
                        }
                    }
                    catch
                    {
                    }
                    return false;
                };
                return jsonProperty;
            }
        }
    }
