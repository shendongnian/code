    public Acs(string apiKey, string apiUrl, string apiPassword = null) : base(apiKey, apiUrl, apiPassword)
    {
        apiKey = "my_api_key";
        apiUrl = "my_api_url";
    }
    public Acs()
    {
        // anything you want here, or nothing.
    }
    public string ApiKey { get; set; }
    public string ApiUrl { get; set; }
