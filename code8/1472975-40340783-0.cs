    public class MyModule1 : IHttpModule
    {
        public void Dispose() {}
        public void Init(HttpApplication context)
        {
            context.AuthorizeRequest += context_AuthorizeRequest;
        }
        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            // Check if the parameter is valid, your logic
            if (ValidateRequest(app.Context.Request))
            {
                // Then do nothing
                return;
            }
            // Otherwise, return unauthorized response
            app.Context.Response.StatusCode = 401;
            app.Context.Response.End();
        }
    }
