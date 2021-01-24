    public class Startup
    {
    	public void Configuration(IAppBuilder app)
    	{
    		app.Use((context, next) =>
    		{
    			if (!IsIpAdressOk(context.Request)) //if the ip is invalid, stop the process and just return a response to the client
    			{
    				return context.Response.WriteAsync("Get lost!");
    			}
    			return Next.Invoke(context); //if the ip is correct then continue to the next middleware
    		});
    		
    		...add OAuthAuthorizationServerProvider and the rest here	
    	}
    }
