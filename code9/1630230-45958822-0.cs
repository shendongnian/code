    public class YourContext: DbContext
          {
              public DbSet<IdentityUser> IdentityUser{ get; set; }
              
              protected override void OnModelCreating(DbModelBuilder modelBuilder)
              {
                  modelBuilder.Entity<IdentityUser>().Property(p => p.Email).HasMaxLength(25);
              }
            }
