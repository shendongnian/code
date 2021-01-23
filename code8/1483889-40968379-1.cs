    using System.Web;
    using Dapper;
    
    [assembly: PreApplicationStartMethod(typeof(YourNamespace.Initiator), "RegisterModels")]
    
    namespace YourNamespace
    {
        public class Initiator
        {
            private static void RegisterModels()
            {
                 SqlMapper.SetTypeMap(typeof(Site), new ColumnAttributeTypeMapper<Site>());
                 SqlMapper.SetTypeMap(typeof(Location), new ColumnAttributeTypeMapper<Location>());
                 // ...
            }
        }
    }
