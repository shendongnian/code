    public class LanguagePack
    {
        [JsonProperty(PropertyName = ="LPT")]
        public string LoginPageTitle{get;set;}
        
        public static LanguagePack Current {get; set;}
    }
