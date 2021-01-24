    public class CityHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var fn = context.Request.QueryString["action"];
            var newCity = context.Request.QueryString["city"];
    
            if (fn == "add")
            {
                // TODO: add city
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write("OK");
        }
    
        public bool IsReusable
        {
            get { return false; }
        }
    }
