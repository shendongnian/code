        public class HeadersModule : IHttpModule
        {
            public void Init(HttpApplication context)
            {
                context.PreSendRequestHeaders += OnPreSendRequestHeaders;
            }
    
            public void Dispose() {
    
            }
    
            void OnPreSendRequestHeaders(object sender, EventArgs e)
            {
    
                var r = sender as HttpApplication;
                r.Response.Headers.Remove("Server");
                r.Response.Headers.Remove("X-AspNetMvc-Version");
                r.Response.Headers.Remove("X-AspNet-Version");
                r.Response.Headers.Remove("X-Powered-By");
            }
        }
    
    
