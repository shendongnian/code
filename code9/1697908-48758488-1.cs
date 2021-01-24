    public class WebHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            var fullFileName = context.Session["fullFileName"];
        }
    }
