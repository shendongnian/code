    public class APIResponse<T> {
        public IEnumerable<T> Result { get; set; }
        [JsonProperty("has-more")]
        public bool HasMore { get; set; }
        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
    
    
    var contactsResponse = JsonConvert.DeserializeObject<APIResponse<Contact>>(json);
    IEnumerable<Contact> contacts = contactsResponse.Result
