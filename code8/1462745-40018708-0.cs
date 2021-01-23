    public static class HttpSessionStateExtension
    {
        public static object Get(this System.Web.SessionState.HttpSessionState session, string key)
        {
            var guid = ???; // no idea where or how you are getting guid, you never explained that in your question
            return session[guid + key];
        }
    }
    // in other methods you can then call it the same as you would the indexer
    var result = System.Web.HttpContext.Current.Session.Get("foo");
