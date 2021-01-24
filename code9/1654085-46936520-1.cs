    public class CallingService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfigurationManager _configurationManager;
        public CallingService(HttpClient httpClient, 
            IConfigurationManager configurationManager)
        {
            _httpClient = httpClient;
            _configurationManager = configurationManager;
        }
        public async Task<XmlNodeList> TransmitToApi(string xml_string)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12;
            //..
            string type = "application/xml";
            var content = new StreamContent(new MemoryStream(Encoding.ASCII.GetBytes(xml_string)));
            var targetUri = new Uri(_configurationManager.GetAppSetting("ApiUrl"));
            var message = new HttpRequestMessage
            {
                RequestUri = targetUri,
                Method = HttpMethod.Post,
                Content = content
            };
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
            message.Content.Headers.Add("Content-Type", type);
            string somedata;
            try
            {
                // Define the cancellation token.
                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;
                var response = await _httpClient.SendAsync(message, token);
                somedata = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //...
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(somedata);
            return xmlDoc.SelectNodes("*");
        }
    }
