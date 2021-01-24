    // General client
    public class CookieAwareWebClient : WebClient
    {
        public CookieContainer CookieContainer { get; private set; }
        public CookieAwareWebClient()
          : this(new CookieContainer())
        { }
        public CookieAwareWebClient(CookieContainer container)
        {
            CookieContainer = container;
        }
        public bool Login(string loginPageAddress, NameValueCollection loginData)
        {
            var request = (HttpWebRequest)WebRequest.Create(loginPageAddress);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.69 Safari/537.36";
            var buffer = Encoding.ASCII.GetBytes(loginData.ToString());
            request.ContentLength = buffer.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Close();
            request.CookieContainer = new CookieContainer();
            var response = (HttpWebResponse)request.GetResponse();
            response.Close();
            CookieContainer = request.CookieContainer;
            return response.StatusCode == HttpStatusCode.OK;                
        }
        
        // Add cookies to WebRequest
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.69 Safari/537.36";
            request.CookieContainer = CookieContainer;
            return request;
        }
    }
