    class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string AlternateName { get; set; }
        [PremiumContent]
        public PremiumStuff ExtraContent { get; set; }
    }
    
    class PremiumStuff
    {
        public string ExtraInfo { get; set; }
        public string SecretInfo { get; set; }
    }
    
    class IncludePremiumContentAttributesResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            foreach (var prop in props)
            {
                if (Attribute.IsDefined(type.GetProperty(prop.PropertyName), typeof(PremiumContent)))
                {
                    //if the attribute is marked with [PremiumContent]
    
                    if (PremiumContentRights.AllowPremiumContent == false)
                    {
                        prop.Ignored = true;   // Ignore this if PremiumContentRights.AllowPremiumContent is set to false
                    }
                }
            }
            return props;
        }
    }
    
    [System.AttributeUsage(System.AttributeTargets.All)]
    public class PremiumContent : Attribute
    {
    }
    
    public static class PremiumContentRights
    {
        public static bool AllowPremiumContent = true;
    }
