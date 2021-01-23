    using System;
    using System.Web;
    
    public class CustomHttpModule : IHttpModule
    {
        private const string URL_TO_LOOK_FOR = "/MultiMediaFiles/";
    
        public CustomHttpModule()
        {
        }
    
        public void Init(HttpApplication app)
        {
            app.AuthenticateRequest += CustomAuthenticateRequest;
        }
    
        void CustomAuthenticateRequest(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;
            Uri url = context.Request.Url;
            if (url.AbsolutePath.StartsWith(URL_TO_LOOK_FOR, StringComparison.OrdinalIgnoreCase))
            {
                var response = context.Response;
                response.Clear();
                response.Write("app.Context.User :");
                if (context.User == null || context.User.Identity == null || context.User.Identity.Name == null)
                {
                    response.Write("No user");
                }
                else
                {
                    response.Write(context.User.Identity.Name);
                }
    
                response.End();
                response.Flush();
                response.Close();
            }
        }
    
        public void Dispose()
        {
        }
    }
