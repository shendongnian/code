    namespace My.Web.Configuration
    {
        using System.Collections.Generic;
    
        public interface IIPWhitelistConfiguration
        {
            IEnumerable<string> AuthorizedIPAddresses { get; }
        }
    }
