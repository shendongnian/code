    public partial class MyDashboardContext : IdentityDbContext<ApplicationUser>
        {
            public MyDashboardContext()
                : base("name=MyDashboardConnection")
            {
            }
    }
