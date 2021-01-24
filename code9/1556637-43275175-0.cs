    public class MyHttpWebRequest : IHttpWebRequest
    {
        private readonly HttpWebRequest httpWebRequest;
    
        public MyHttpWebRequest(HttpWebRequest httpWebRequest)
        {
            this.httpWebRequest = httpWebRequest;
        }
    
        public bool UseDefaultCredentials
        {
            get { return this.httpWebRequest.UseDefaultCredentials;  }
            set { this.httpWebRequest.UseDefaultCredentials = value; }
        }
    
        public IWebResponse GetResponse()
        {
            return new MyWebResponse((HttpWebResponse)httpWebRequest.GetResponse());
        }
    }
