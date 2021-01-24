    public class ApiResponse
    {
        public Success success { get; set; }
    }
    
    public class Success
    {
        [JsonProperty("orderId")]
        public static string orderId { get; set; }
    
        [JsonProperty("pair")]
        public static string pair { get; set; }
    
        [JsonProperty("withdrawal")]
        public static string withdrawal { get; set; }
    
        [JsonProperty("withdrawalAmount")]
        public static string withdrawalAmount { get; set; }
    
        [JsonProperty("deposit")]
        public static string deposit { get; set; }
    
        [JsonProperty("depositAmount")]
        public static string depositAmount { get; set; }
    
        [JsonProperty("expiration")]
        public static string expiration { get; set; }
    
        [JsonProperty("quotedRate")]
        public static string quotedRate { get; set; }
    
        [JsonProperty("maxLimit")]
        public static string maxLimit { get; set; }
    
        [JsonProperty("apiPubKey")]
        public static string apiPubKey { get; set; }
    
        [JsonProperty("minerFee")]
        public static string minerFee { get; set; }
    }
