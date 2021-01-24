    public class Acs : ActiveCampaignService
    {
        // Assuming you have class properties to hold values passed in from constructor
        private string ApiKey { get; set; }
        private string ApiUrl { get; set; }
        private string ApiPassword { get; set; }
        // Default constructor takes no arguments. Passes default values to next constructor
        public Acs() : this ("my_api_key", "my_api_url")
        { }
        // This constructor takes two arguments and passes them to
        // the next constructor, passing null for the apiPassword
        public Acs(string apiKey, string apiUrl) : this(apiKey, apiUrl, null)
        { }
        // This is the final constructor that does something 
        // with the values, and calls the base constructor
        public Acs(string apiKey, string apiUrl, string apiPassword) 
            : base(apiKey, apiUrl, apiPassword)
        {
            ApiKey = apiKey;
            ApiUrl = apiUrl;
            ApiPassword = apiPassword;
        }
    }
