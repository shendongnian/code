    public class WebServer {
        string[] Uris;
        public WebServer(Func<HttpListenerRequest, string> sendResponse, IEnumerable<string> ipAdressenLijst)
        {
            Uris = ipAdressenLijst.ToArray();
        }
    }
