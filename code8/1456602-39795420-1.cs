    public class APIResponseBase {
        [JsonProperty("has-more")]
        public bool HasMore { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
    
    public class ContactsResponse : APIResponseBase {
      public IEnumerable<Contact> Contacts { get; set; }
    }
    
    public class CompaniesResponse : APIResponseBase {
      public IEnumerable<Company> Companies { get; set; }
    }
    
    var contactsResponse = JsonConvert.Deserialize<ContactsResponse>(json);
    IEnumerable<Contact> contacts = contactsResponse.Contacts
