    public class ImageHandler : IHttpHandler
    {        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(HttpContext context)
        {
            // Handle your request here, using 
            // context.Request and System.IO 
            // to serve the image from network
        }
    }
