    public class UserImagesHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //Get username from from query string
    
            //Get binary data
    
            context.Response.ContentType = "image/jpeg";
            context.Response.BinaryWrite(bytes);
        }
    }
