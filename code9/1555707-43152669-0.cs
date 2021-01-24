    public class FlatResolver : DefaultContractResolver
    {
      public static JsonSerializerSettings Settings =
        new JsonSerializerSettings { ContractResolver = new FlatResolver() };
    
      protected override IList<JsonProperty> CreateProperties (Type type, MemberSerialization memberSerialization)
      {
        IList<JsonProperty> properties = base.CreateProperties (type, memberSerialization);
    
        properties = properties
          .Where (p => !p.PropertyType.GetCustomAttributes (typeof (System.Data.Linq.Mapping.TableAttribute)).Any())
          .ToList();
    
        return properties;
      }
    }
