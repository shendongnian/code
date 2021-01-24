    public class PayeeContactGroup
     {   
        [JsonProperty("payee_contacts")]    
        public List<PayeeContactDetails> PayeeContact { get; set; } = new List<PayeeContactDetails>();
    
     }
