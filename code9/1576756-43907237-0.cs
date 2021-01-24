    namespace HelloWorldBot
    {
    public static class IdentityExtensions
    {
    	public static Guid Test(this IIdentity identity)
    	{
    		return Guid.Empty;
    	}
    
    	public static string GetUserId(this IIdentity identity)
    	{
    		return "";
    	}
    }
    
    public class myController : ApiController
    {
    	public void Test()
    	{
    		var tvalue = User.Identity.Test();
    	} 
    }
    }
