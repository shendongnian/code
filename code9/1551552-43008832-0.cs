    public class ApplicationUserClaim : IdentityUserClaim
    {
    	public ApplicationUserClaim() { }
    
    	public ApplicationUserClaim(string userId, string claimType,
    		string claimValue, string externalSystem)
    	{
    		UserId = userId;
    		ClaimType = claimType;
    		ClaimValue = claimValue;
    		ExternalSystem = externalSystem;
    	}
    	
    	[MaxLength(64)]
    	public string ExternalSystem { get; set; }
    }
