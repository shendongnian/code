    // your existing context
    public class AppDbContext : DbContext { 
        private readonly bool turnOfIdentity = false;
        public AppDbContext(bool turnOfIdentity = false){
            this.turnOfIdentity = turnOfIdentity;
        }
        public DbSet<IdentityItem> IdentityItems {get;set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityItem>()
               .HasKey( i=> i.Id )
               // this tells EF not to send Identity to SQL Server
               .HasDatabaseGeneratedOption(
                   turnOfIdentity ?
                       DatabaseGeneratedOption.None,
                       DatabaseGeneratedOption.Identity
               );
      
        }
    }
    public class IdentityItem{
        
    }
