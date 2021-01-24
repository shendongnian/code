    namespace KatanaSelfHost
        {
            class Startup
            {
                public void Configuration(IAppBuilder app)
                {
                    HttpListener listener = 
                        (HttpListener)app.Properties["System.Net.HttpListener"];                    
    listener.AuthenticationSchemeSelectorDelegate = 
        new AuthenticationSchemeSelector (AuthenticationSchemeForClient);
    
    
                    app.Run(context =>
                    {
                        context.Response.ContentType = "text/plain";
                        return context.Response.WriteAsync("Hello World!");
                    });
                }
            }
        }
        static AuthenticationSchemes AuthenticationSchemeForClient(HttpListenerRequest request)
        {
            Console.WriteLine("Client authentication protocol selection in progress...");
            // check the url here
            if (request.RawUrl.Contains("/secure"))
            {
                return AuthenticationSchemes.IntegratedWindowsAuthentication;
            }
            else
            {
                return AuthenticationSchemes.None;
            }
        }
