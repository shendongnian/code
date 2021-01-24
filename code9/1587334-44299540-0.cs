    public class HtmlFileHandler: IHttpHandler
    {        
        public void ProcessRequest(HttpContext context)
        {
            var htmlFileRequested = HttpContext.Current.Request.Url.Segments.Contains(".html");
            if (htmlFileRequested)
            {
              // return file by context.Response.WriteFile("");
              // don't forget: context.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {
              //redirect to controller factory
            }
        }
        public bool IsReusable
        {
            // To enable pooling, return true here.
            // This keeps the handler in memory.
            get { return false; }
        }
    }
