    public class Account
    {
        [JsonProperty("@odata.context")]
        public string myText { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
    string json = @"{
      '@odata.context': 'this is an attribute with an @ in the name.',
      'Active': true,
      'CreatedDate': '2013-01-20T00:00:00Z',
      'Roles': [
        'User',
        'Admin'
      ]
    }";
    
    Account account = JsonConvert.DeserializeObject<Account>(json);
    
    Console.WriteLine(account.myText);
    // this is an attribute with an @ in the name.
