    I had the same thing, but i needed to hide as much as possible, its the same for Add or Remove or both, its just headers.
    
    1e you can set MvcHandler.DisableMvcResponseHeader = true; in the global.asax
    
            protected void Application_Start()
            {
                MvcHandler.DisableMvcResponseHeader = true;
            }
    
    and
    
            protected void Application_PreSendRequestHeaders()
            {
                Response.Headers.Remove("Server");
                Response.Headers.Remove("X-AspNet-Version");
            }
    
    
    
    2e you should not really use diff module for almost the same job, instead create a HeaderModule that only handles header modification, and use the
    PreSendRequestHeaders to add or remove any headers that you want. (you can always inject some service with list of headers to add or remove)
    
    
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
    
    
    
    3e to be extra sure, that some headers show, or "not" show up you can add this to yr config file
      <system.webServer>
        <modules>
          <add name="HeadersModule " type="MyNamespace.Modules.HeadersModule " />
        </modules>
        <httpProtocol>
          <customHeaders>
            <remove name="X-Powered-By" />
            <remove name="Server" />
            <remove name="X-AspNet-Version" />
            <remove name="X-AspNetMvc-Version" />
          </customHeaders>
          <redirectHeaders>
            <clear />
          </redirectHeaders>
        </httpProtocol>
      </system.webServer>
    
    4e test all pages, aka 404, error pages, weird path names, cause the can leak certain headers or show headers that you did not expect.
    
    5e, greets, 
