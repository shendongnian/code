    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest w = (HttpWebRequest)base.GetWebRequest(uri);
            w.ProtocolVersion = Version.Parse("1.0");
            return (WebRequest)w;
        }
    }
