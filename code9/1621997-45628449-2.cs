    public class MyController : Controller
    {
    	private readonly UserManager<User> _userManager;
    	public MyController(UserManager<User> userManager)
    	{
    		_userManager = userManager;
    	}
    	
    	
    	[HttpGet("whatever")]
    	public async Task<IActionResult> GetWhatever()
    	{
    	    // this will get your user from the UserStore, 
    		// based on the ClaimsIdentity.UserIdClaimType from the ClaimsPrincipal
    		MyUser myUser = await _userManager.GetUserAsync(User);
    	}
    }
