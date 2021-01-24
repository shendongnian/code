    public class MyRole : IdentityRole<int>
    {
        public MyRole() : base()
        {
        }
        
        public MyRole(string roleName)
        {
            Name = roleName;
        }
    }
    public void ConfigureServices(IServiceCollection services)
            {
                services.AddIdentity<MyApplicationUser, MyRole>(config =>
                {
                    config.User.RequireUniqueEmail = true;
                    config.Password.RequiredLength = 8;
                }).AddEntityFrameworkStores<MyApplicationContext>();
                ...
