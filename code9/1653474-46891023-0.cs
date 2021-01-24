    public bool checkWebsite(string URL) {
       try {
          WebClient wc = new WebClient();
          string HTMLSource = wc.DownloadString(URL);
          return true;
       }
       catch (Exception) {
          return false;
       }
    }
