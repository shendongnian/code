    public class DoctorsDbContext : IdentityDbContext<ApplicationUser>
    {
        static DoctorsContext()
        {
            Database.SetInitializer<IdentityDbContext>(null);
            Database.SetInitializer<DoctorsDbContext>(null);
        }
        public DoctorsDbContext()
            : base("Name=nameOfConnectionString")
        {
           Database.SetInitializer<IdentityDbContext>(null);
           Database.SetInitializer<DoctorsDbContext >(null);
        }
     protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>()
                           .ToTable("dbo.AspNetUsers");
            modelBuilder.Entity<ApplicationUser>()
                          .ToTable("dbo.AspNetUsers");
            modelBuilder.Entity<IdentityRole>()
                         .ToTable("dbo.AspNetRoles");
            modelBuilder.Entity<ApplicationRole>()
                         .ToTable("dbo.AspNetRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("dbo.AspNetUserClaims");
            modelBuilder.Entity<IdentityUserRole>().ToTable("dbo.AspNetUserRoles");
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("dbo.AspNetUserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("dbo.AspNetUserLogins");
                 }
