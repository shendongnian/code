    public class CustomRouteHttpModule : IHttpModule
    {
        private const string customPrefix = "/custom";
        public void Init(HttpApplication context)
        {
            context.BeginRequest += BeginRequest;
        }
        private void BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            if (context.Request.RawUrl.ToLower().StartsWith(customPrefix)
            && string.Compare(context.Request.HttpMethod, "GET", true) == 0)
            {
                var urlWithoutCustom = context.Request.RawUrl.Substring(customPrefix.Length);
                context.RewritePath(urlWithoutCustom);
            }
        }
        public void Dispose()
        {
        }
    }
