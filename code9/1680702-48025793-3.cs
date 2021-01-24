    public class EbayClient
    {
        // Don't do this, use a proper method of storing app secrets.
        // I have it this way for simplicity in this example.
        const string AppId = "MyAppId";
        const string DevId = "MyDevId";
        const string CertId = "MyCertId";
        const string AuthToken = "MyAuthToken";
    
        // This is the version of the API that your WSDL file is from. As of this answer
        // the latest version is 1039. All calls need this passed as a parameter.
        const string Version = "1039";
    
        // This is the base URL for the API.
        // Sandbox: https://api.sandbox.ebay.com/wsapi
        // Production: https://api.ebay.com/wsapi
        const string BaseApiUrl = "https://api.sandbox.ebay.com/wsapi";
    
        // This is the actual client from the service we just imported. It's being injected
        // here via the built-in DI in ASP.NET Core.
        readonly eBayAPIInterfaceClient _ebay;
    
        // All of the functions in this class need these credentials passed, so declare it in
        // the constructor to make things easier.
        readonly CustomSecurityHeaderType _creds;
    
        public EbayClient(eBayAPIInterfaceClient ebay)
        {
            _ebay = ebay;
    
            _creds = new CustomSecurityHeaderType
            {
                Credentials = new UserIdPasswordType
                {
                    AppId = AppId,
                    DevId = DevId,
                    AuthCert = CertId
                },
                eBayAuthToken = AuthToken
            };
        }
    
        // This is a wrapper around the API GetItem call.
        public async Task<GetItemResponse> GetItemAsync(string itemId)
        {
            // All of the API requests and responses use their own type of object.
            // This one, naturally, uses GetItemRequest and GetItemResponse.
            var reqType = new GetItemRequest
            {
                GetItemRequest1 = new GetItemRequestType
                {
                    ItemID = itemId,
                    Version = Version
                },
                RequesterCredentials = _creds
            };
    
            // The service isn't smart enough to know the endpoint URLs itself, so
            // we have to set it explicitly.
            var addr = new EndpointAddress($"{ApiBaseUrl}?callname=GetItem");
    
            // This creates a channel from the built-in client's ChannelFactory.
            // See the WCF docs for explanation of this step.
            var ch = _ebay.ChannelFactory.CreateChannel(addr);
    
            // Actually call the API now
            var itemResp = await ch.GetItemAsync(reqType);
    
            // Check that the call was a success
            if (itemResp.GetItemResponse1.Ack == AckCodeType.Success)
            {
                // The call succeeded, so handle the data however you want. I created
                // a class to simplify the API class because the API class is massive.
                return new EbayItem
                {
                    ItemId = itemResp.GetItemResponse1.Item.ItemID,
                    Price = Convert.ToDecimal(itemResp.GetItemResponse1.Item.BuyItNowPrice.Value),
                    QuantityAvailable = itemResp.GetItemResponse1.Item.QuantityAvailable
                };
            }
    
            // Handle an API error however you want. Throw an
            // exception or return null, whatever works for you.
            return null;
        }
    }
