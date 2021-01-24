    using Newtonsoft.Json;
    using System.Collections.Generic;
    
    namespace Accounts
    {
        class Account
        {
            [JsonProperty("accountName")]
            public string AccountName { get; set; }
    
            [JsonProperty("files")]
            public List<File> Files { get; set; }
        }
    }
