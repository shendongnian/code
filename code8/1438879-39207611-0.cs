    <%@ WebHandler Language="C#" Class="Handler1" %>
    
    using System;
    using System.Web;
    
    public class Handler1 : IHttpHandler {
        
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }
     
        public bool IsReusable {
            get {
                return false;
            }
        }
    
    }
