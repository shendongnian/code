    public class sampleClass : IHttpHandler {
    public void ProcessRequest (HttpContext context) {
    context.Response.ContentType = "text/plain";
    var id = "someid"; //implement the id that you want to pass to the Javascript function
    ClientScript.RegisterStartupScript(this.GetType(), "methodtocall", id, true);
    }
    }
