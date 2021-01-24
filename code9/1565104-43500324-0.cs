    public class CustomResolver : DefaultContractResolver
    {
        private Type AttributeTypeToLookFor { get; set; }
        public CustomResolver(Type attributeTypeToLookFor)
        {
            AttributeTypeToLookFor = attributeTypeToLookFor;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
            foreach (JsonProperty prop in list)
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if (pi != null)
                {
                    // if the property has any attribute other than 
                    // the specific one we are seeking, don't serialize it
                    if (pi.GetCustomAttributes().Any() &&
                        pi.GetCustomAttribute(AttributeTypeToLookFor) == null)
                    {
                        prop.ShouldSerialize = obj => false;
                    }
                }
            }
            return list;
        }
    }
