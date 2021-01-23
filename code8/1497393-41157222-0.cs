    public class ProfileSmallViewComponent : ViewComponent
    {
    	private readonly UserManager<ApplicationUser> _userManager;
    
    	public ProfileSmallViewComponent(UserManager<ApplicationUser> userManager)
    	{
    		_userManager = userManager;
    	}
    
    	public async Task<IViewComponentResult> InvokeAsync()
    	{
    		var users = await _userManager.Users.ToListAsync();
    		return await Task.FromResult<IViewComponentResult>(View("Default", users));
    	}
    }
