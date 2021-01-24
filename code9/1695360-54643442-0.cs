    using System.Threading.Tasks;
    using System.Collections.Generic;
    using CefSharp;
    
    namespace Extensions
    {
        public static class WebBrowserExtensions
        {
            public static Task SetProxy(this IWebBrowser webBrowser, string address)
            {
                return Cef.UIThreadTaskFactory.StartNew(() =>
                {
                    var context = webBrowser.GetBrowser().GetHost().RequestContext;
    
                    context.SetPreference("proxy", new Dictionary<string, object>
                    {
                        ["mode"] = "fixed_servers",
                        ["server"] = address
                    }, out _);
                });
            }
        }
    }
