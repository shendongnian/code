    using System;
    using System.Web;
    public class SavePositionHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string LeftPos = context.Request.Form["LeftPos"];
            string TopPos = context.Request.Form["TopPos"];
            
            //now you have the data on the server side. Save it to database.
        }
        public bool IsReusable
        {
           get
           {
                return false;
           }
        }
    }
