    public sealed class ShopifyAPIGateway : IShopifyAPIGateway
            {
                /// <summary>
                /// 
                /// </summary>
                private Identity _identity;
                /// <summary>
                /// 
                /// </summary>
                private HttpClient _httpClient;
                /// <summary>
                /// 
                /// </summary>
                public ShopifyAPIGateway(Identity
                    identity)
                {
                    _identity = identity;
                    _httpClient = new HttpClient(ClientHandler());
                }
                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                public HttpResponseMessage Get(string path)
                {
                    try
                    {
                        var response =  Connect().GetAsync(path).Result;
                        return response;
                    }
                    catch (CustomHttpResponseException ex)
                    {
                        new Email().SendEmail(_identity.ClientName, "Http Response Error - Shopify API Module",
                         "Http Response Error - Shopify API Module: " + ex.Message,
                         "error@retain.me");
        
                        throw new CustomHttpResponseException(ex.Message);
                    }
        
                }
                /// <summary>
                /// 
                /// </summary>
                /// <returns></returns>
                private HttpClient Connect()
                {
                    try
                    {
                        _httpClient.BaseAddress = new Uri(_identity.APIURL);
                        return _httpClient;
                    }
                    catch (CustomHttpRequestException ex)
                    {
                        throw new CustomHttpRequestException(ex.Message);
                    }
        
                }
                /// <summary>
                /// 
                /// </summary>
                /// <param name="userKey"></param>
                /// <returns></returns>
                private HttpClientHandler ClientHandler()
                {
                    try
                    {
                        return new HttpClientHandler()
                        {
                            Credentials = new NetworkCredential(_identity.APIKey,
                                                                _identity.Password),
                            PreAuthenticate = true
                        };
                    }
                    catch (CustomClientHandlerException ex)
                    {    
                        throw new CustomClientHandlerException(ex.Message);   
                    }
                }
            }
