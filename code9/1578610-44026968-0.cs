    public class FacebookChannelData
    {
        [JsonProperty("Sender")]
        public Sender Sender { get; set; }
        
        [JsonProperty("Recipient")]
        public Recipient Recipient { get; set; }
    
        [JsonProperty("Timestamp")]
        public long Timestamp { get; set; }
    
        [JsonProperty("Postback")]
        public Postback Postback { get; set; }
    
        [JsonProperty("Referral")]
        public Referral Referral { get; set; }
    
        public string RefParameter
        {
            get
            {
                string val = "";
    
                if (Postback != null && Postback.Referral != null && !String.IsNullOrWhiteSpace(Postback.Referral.Reference))
                {
                    val = Postback.Referral.Reference;
                }
                else if (Referral != null && !String.IsNullOrWhiteSpace(Referral.Reference))
                {
                    val = Referral.Reference;
                }
                return val;
            }
        }
    }
    
    public class Recipient
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
    
    public class Sender
    {
        [JsonProperty("Id")]
        public string Id { get; set; }
    
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
    
    public class Postback
    {
        [JsonProperty("Payload")]
        public string Payload { get; set; }
    
        [JsonProperty("Referral")]
        public Referral Referral { get; set; }
    }
    
        public class Referral
        {
            [JsonProperty("Ref")]
            public string Reference { get; set; }
    
            [JsonProperty("Source")]
            public string Source { get; set; }
    
            [JsonProperty("Type")]
            public string Type { get; set; }
    }
