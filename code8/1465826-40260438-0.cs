        public static string Authenticate()
        {
            // (1) Build request 
            var client = new RestClient();
            client.BaseUrl = new System.Uri(baseApiUrl);
            // Set resource/end point
            var request = new RestRequest();
            request.Resource = "authentication/v1/authenticate";
            request.Method = Method.POST;
            // Set required parameters 
            request.AddParameter("client_id", consumerKey);
            request.AddParameter("client_secret", consumerSecret);
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("scope", "data:read data:create data:write bucket:read bucket:create");
            // (2) Execute request and get response
            IRestResponse response = client.Execute(request);
            // Save response. This is to see the response for our learning.
            m_lastResponse = response;
            // Get the access token. 
            string accessToken = "";
            if (response.StatusCode == HttpStatusCode.OK)
            {
                JsonDeserializer deserial = new JsonDeserializer();
                Share_Model_OSSClasses loginResponse = deserial.Deserialize<Share_Model_OSSClasses>(response);
                accessToken = loginResponse.access_token;
            }
            return accessToken;
        }
    public class Share_Model_OSSClasses
    {
        public string token_type { get; set; }
        public string expires_in { get; set; } // expiry time in seconds. (30 min) 
        public string access_token { get; set; }
    }
