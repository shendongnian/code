    public class RSAContractResolver : DefaultContractResolver
    {
      protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
      {
        IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
        if (type == typeof(RSAParameters))
        {
            foreach(var property in properties)
            {
                property.Ignored = false;
            }
        }
        
        return properties;
      }
    }
