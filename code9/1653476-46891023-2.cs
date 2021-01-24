    class MyClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest req = base.GetWebRequest(address);
            req.Method = "HEAD";
            return req;
        }
    }
    public bool checkWebsite(string URL) {
       try {
          MyClient wc = new MyClient();
          string HTMLSource = wc.DownloadString(URL);
          return true;
       }
       catch (Exception) {
          return false;
       }
    }
