    public class CustomClaimsMapper : ICommandHandler<MapClaimsFromAccount<CustomUserAccount>>
    {
    	public void Handle(MapClaimsFromAccount<CustomUserAccount> cmd)
    	{
    		cmd.MappedClaims = new System.Security.Claims.Claim[]
    		{
    			new System.Security.Claims.Claim(ClaimTypes.GivenName, cmd.Account.FirstName),
    			new System.Security.Claims.Claim(ClaimTypes.Surname, cmd.Account.LastName),
    		};
    	}
    }
