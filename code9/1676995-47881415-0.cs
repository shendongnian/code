    class WebClientWithTimeout : WebClient {
      public WebClientWithTimeout(int timeout) {
        _timeout = timeout
      }
      // Timeout in seconds
      int _timeout;
      protected override WebRequest GetWebRequest(Uri uri) {
        WebRequest webRequest = base.GetWebRequest(uri);
        webRequest.Timeout = 1000 * _timeout;
        return w;
      }
    }
