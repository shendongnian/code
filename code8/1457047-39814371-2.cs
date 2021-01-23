        public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public ApplicationDbContext() : base("DefaultConnection")
            {
                 //unchanged
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                //unchanged
                OnModelCreating2(modelBuilder);
            }
        }
 
