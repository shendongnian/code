    public class QueryStringHandler : IHttpHandler 
    {
        public void ProcessRequest (HttpContext context) 
        {
    
     //set the content type, you can either return plain text, html text, or json or other type    
    		context.Response.ContentType = "text/plain";
    
    		//deserialize the object
    		UserInfo objUser = Deserialize<HandlerModel>(context);
    		
    		//now we print out the value, we check if it is null or not
    		if (objUser != null) {
    			context.Response.Write("Go the Objects");
    		} else {
    			context.Response.Write("Sorry something goes wrong.");
    		}
    }
    
    public T Deserialize<T>(HttpContext context) {
    		//read the json string
    		string jsonData = new StreamReader(context.Request.InputStream).ReadToEnd();
    
    		//cast to specified objectType
    		var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);
    
    		//return the object
    		return obj;
    	}
    }
