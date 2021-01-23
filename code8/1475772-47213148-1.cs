    namespace My.Web.Configuration
    {
        using System.Collections.Generic;
    
        public class IPWhitelistConfiguration : IIPWhitelistConfiguration
        {
            public IEnumerable<string> AuthorizedIPAddresses { get; set; }
        }
    }
