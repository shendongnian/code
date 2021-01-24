    public class IdentitySeed
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _rolesManager;
        private readonly ILogger _logger;
        public IdentitySeed(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
             ILoggerFactory loggerFactory) {
            _context = context;
            _userManager = userManager;
            _rolesManager = roleManager;
            _logger = loggerFactory.CreateLogger<IdentitySeed>();
        }
        public async Task CreateRoles() {
            if (await _context.Roles.AnyAsync()) {// not waste time
                _logger.LogInformation("Exists Roles.");
                return;
            }
            var adminRole = "Admin";
            var roleNames = new String[] { adminRole, "Manager", "Crew", "Guest", "Designer" };
            foreach (var roleName in roleNames) {
                var role = await _rolesManager.RoleExistsAsync(roleName);
                if (!role) {
                    var result = await _rolesManager.CreateAsync(new ApplicationRole { Name = roleName });
                    //
                    _logger.LogInformation("Create {0}: {1}", roleName, result.Succeeded);
                }
            }
            // administrator
            var user = new ApplicationUser {
                UserName = "Administrator",
                Email = "something@something.com",
                EmailConfirmed = true
            };
            var i = await _userManager.FindByEmailAsync(user.Email);
            if (i == null) {
                var adminUser = await _userManager.CreateAsync(user, "Something*");
                if (adminUser.Succeeded) {
                    await _userManager.AddToRoleAsync(user, adminRole);
                    //
                    _logger.LogInformation("Create {0}", user.UserName);
                }
            }
        }
        //! By: Luis Harvey Triana Vega
    }
