    internal class User
    {
     [JsonProperty("UserName ")]
     public string UserName { get; set; }
     [JsonProperty("UserPassword")]
     public string UserPassword { get; set; }
     [JsonProperty("Accounts ")]
     public List<Account> Accounts { get; set; }
    }
