    private class ExtendedWebClient : System.Net.WebClient
    {
        public long ContentLength { get; set; }
        public ExtendedWebClient(long contentLength)
        {
            ContentLength = contentLength;
        }
        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            System.Net.HttpWebRequest hwr = (System.Net.HttpWebRequest)base.GetWebRequest(uri);
            hwr.AllowWriteStreamBuffering = false; //do not load the whole file into RAM
            hwr.ContentLength = ContentLength;
            return (System.Net.WebRequest)hwr;
        }
    }
