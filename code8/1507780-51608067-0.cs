    public class AuthenticatedRequest
    {
	    [FromHeader(Name = "User-Identity")]
	    public string UserIdentity { get; set; }
    }
