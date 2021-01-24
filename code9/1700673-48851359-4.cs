    public class SimpleHttpHandler: IHttpHandler 
    { 
      public void ProcessRequest(System.Web.HttpContext context){ 
        context.Response.Write("The page request ->" +          
        context.Request.RawUrl.ToString()); 
      } 
      public bool IsReusable 
      { 
        get{ return true; } 
      } 
    } 
