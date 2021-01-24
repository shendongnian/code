    public class WebServer {
        string[] Uris;
        public WebServer(IEnumerable<string> ipAdressenLijst)
        {
            Uris = ipAdressenLijst.ToArray();
        }
    }
