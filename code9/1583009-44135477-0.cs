    <%@ WebHandler Language="C#" Class="GetDoc" %>
    using System;
    using System.Web;
    
    public class GetDoc : IHttpHandler {
    
        public void ProcessRequest (HttpContext context) {
            context.Response.ContentType = "Application/pdf";
            context.Response.WriteFile("koby.pdf");
            context.Response.End();
        }
    
        public bool IsReusable {
            get {
                return false;
            }
        }
    }
