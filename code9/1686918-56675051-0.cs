    //Creation of class
    public class RolesModel : PageModel
    {
    	private readonly UserManager<IdentityUser> _userManager;
    	private readonly RoleManager<IdentityRole> _roleManager;
    	private readonly ILogger<RolesModel> _logger;
    
    	public RolesModel(
    		UserManager<IdentityUser> userManager,
    		RoleManager<IdentityRole> roleManager,
    		ILogger<RolesModel> logger)
    	{
    		_userManager = userManager;
    		_roleManager = roleManager;
    		_logger = logger;
    	}
    
    //(...)
    //Now check in some class 
    
    public async Task<IActionResult> OnGetAsync()
    {
    	var RolesList = _roleManager.Roles.OrderBy(x => x.Name).ToList();
    
    	foreach (var role in RolesList)
    	{
    		var RolesUserlist = await _userManager.GetUsersInRoleAsync(role.Name);
    		_logger.LogInformation($"Role {role.Name} has {RolesUserlist.Count} users");	
    	}
    }
