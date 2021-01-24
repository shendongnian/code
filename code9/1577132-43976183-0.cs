      namespace TestSharepoint
    {
      public class SharepointHelper
      {
        private ClientContext clientContext;
        private Web rootWeb;
    
        public SharepointHelper(string url, string username, string password)
        {
          clientContext = new ClientContext(url);
          var credentials = new NetworkCredential(username, password, "oshirowanen.com");
          clientContext.Credentials = credentials;
          rootWeb = clientContext.Web;
          clientContext.Load(rootWeb,web=>web.title);
        clientContent.ExecuteQuery();
        string siteTitle=web.title;
                }
              }
            }
