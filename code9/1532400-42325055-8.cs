    public class WebClientEx : WebClient
    {
        private readonly long from;
        private readonly long to;
        public WebClientEx(long from, long to)
        {
            this.from = from;
            this.to = to;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.AddRange(this.from, this.to);
            return request;
        }
    }
