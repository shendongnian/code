    public interface IDbInitializer
    {
        void Initialize();
    }
    (...)
     public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //This example just creates an Administrator role and one Admin users
        public async void Initialize()
        {
            //create database schema if none exists
            _context.Database.EnsureCreated();
            //Create the default Admin account
            string password = "password";
            ApplicationUser user = new ApplicationUser {
                UserName = "Admin",
                Email = "my@mail.com",
                EmailConfirmed = true               
            };            
            user.Claims.Add(new IdentityUserClaim<string> { ClaimType = ClaimTypes.Role, ClaimValue = "Admin" });
            var result = await _userManager.CreateAsync(user, password);            
        }
    }
