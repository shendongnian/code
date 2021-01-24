    class Program
    {
        public const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        public const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = Tls12;
    
            HttpWebRequest webRequest = HttpWebRequest.Create("https://www.fda.gov/ucm/groups/fdagov-public/@fdagov-drugs-gen/documents/document/ucm509432.pdf") as HttpWebRequest;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; Trident/7.0; Touch; rv:11.0) like Gecko";
            webRequest.Accept = "text/html, application/xhtml+xml, */*";
            webRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
            webRequest.Headers.Add("Accept-Language", "tr-TR");
            webRequest.Headers.Add("DNT", "1");
    
            using (var
                 response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                var strContent = reader.ReadToEnd();
            }
        }
    }
