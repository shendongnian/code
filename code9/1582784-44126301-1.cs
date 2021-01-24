     public class Example: System.Web.Services.WebService
        {
    
            [WebMethod]
            public void exampleMethod(Parameters)
            {
                // Something you wanna do
    
               //If you wanna return something to javascript 
                Context.Response.ContentType = "text/HTML";
                var js = new JavaScriptSerializer();
                Context.Response.Write(js.Serialize(returnDataObject));
            }
    }
