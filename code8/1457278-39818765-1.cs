    public class AppUserToUserTransformer : ITransformer<ApplicationUser, User>
    {
    	public User Transform(ApplicationUser source)
    	{
    		return new User
    		{
    			Username = source.Username;
    			Email = source.Email;
    			//continue with the rest of the available properties
    		};
    	}
    } 
