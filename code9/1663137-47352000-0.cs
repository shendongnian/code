    public class ProductApiRequest
    {
        private string _api;
        private string _apiKey;
        private string _apiSecretKey;
        private string _resource;
    
        public ProductApiRequest()
        {
            _api = "https://someurl.com/api/";
            _apiKey = "526587410g44p9kk8f7h2bb2zf3365va";
            _apiSecretKey = "DlKST1adTpoWELS8TjjBc1pFATdlGA8qHUNEaq9MOSAUT648AlAvzK4EEC7=";
            _resource = "products";
        }
    
        public class Product
        {
            public Guid assertion_id { get; set; }
            public String api_key { get; set; }
            public string product_id { get; set; }
            public string product_name { get; set; }
            public string price { get; set; }
            public string timestamp { get; set; }
            public string nonce { get; set; }
            public string signature { get; set; }
        }
    
        public string getProduct()
        {
            Product oProduct = new Product();
    
            oProduct.assertion_id = Guid.NewGuid();
            oProduct.api_key = _apiKey;
            oProduct.product_id = "product001";
            oProduct.product_name = "Useless Product";
            oProduct.price = "1.99";
            oProduct.timestamp = GenerateTimeStamp();
            oProduct.nonce = GenerateNonce();
    
            // Create Signature Base String.
            string apiEncoded = Uri.EscapeDataString(_api + _resource);
            string strSignatureBase = "GET&" + apiEncoded + "&api_key=" + oProduct.api_key + "&product_id=" + oProduct.product_id + "&product_name=" + oProduct.product_name + "&price=" + oProduct.price + "&nonce=" + oProduct.nonce + "&timestamp=" + oProduct.timestamp;
    
            // Create Signature for OAuth 1.0
            oProduct.signature = GenerateSignature(strSignatureBase, _apiSecretKey);
    
            var client = new RestClient(_api + _resource + "?assertion_id=" + oProduct.assertion_id + "&api_key=" + oProduct.api_key + "&product_id=" + oProduct.product_id + "&product_name=" + oProduct.product_name + "&price=" + oProduct.price + "&timestamp=" + oProduct.timestamp + "&nonce=" + oProduct.nonce + "&signature=" + HttpUtility.UrlEncode(oProduct.signature));
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
    
            return "Return whatever you want.";
        }
    
        public string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            string timeStamp = ts.TotalSeconds.ToString();
            timeStamp = timeStamp.Substring(0, timeStamp.IndexOf("."));
            return timeStamp;
        }
    
        public string GenerateNonce()
        {
            var _random = new Random();
            var sb = new StringBuilder();
            for (int i = 0; i < 8; i++)
            {
                int g = _random.Next(3);
                switch (g)
                {
                    case 0:
                        // lowercase alpha
                        sb.Append((char)(_random.Next(26) + 97), 1);
                        break;
                    default:
                        // numeric digits
                        sb.Append((char)(_random.Next(10) + 48), 1);
                        break;
                }
            }
            return sb.ToString();
        }
    
        public string GenerateSignature(string strSignatureBase, string strSecretKey)
        {
            byte[] signatureBaseBytes = Encoding.UTF8.GetBytes(strSignatureBase);
            byte[] secretKeyDecodedBytes = Convert.FromBase64String(strSecretKey); // Decode Secret Key.
    
            var encoder = new UTF8Encoding();
            var hasher = new HMACSHA1(secretKeyDecodedBytes);
    
            byte[] hashedDataBytes = hasher.ComputeHash(signatureBaseBytes);
    
            return Convert.ToBase64String(hashedDataBytes);
        }
    }
