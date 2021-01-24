    public class BrowserTabId 
    {
        public string browserTabId;
        public BrowserTabId(string tabId)
        {
            if(string.IsNullOrEmpty(tabId))
            {
                throw new NullArgumentException();
            }
            this.browserTabId = tabId;
        }
        public string Id { get { return this.browserTabId; } }
    }
    Bind<BrowserTabId>()
        .ToMethod(ctx => 
            new BrowserTabId(HttpContext.Items["BrowserTabId"] as string)))
        .InRequestScope();
