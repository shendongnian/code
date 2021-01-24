    // your existing context
    public abstract class BaseAppDbContext : DbContext { 
        private readonly bool turnOfIdentity = false;
        protected AppDbContext(bool turnOfIdentity = false){
            this.turnOfIdentity = turnOfIdentity;
        }
        public DbSet<IdentityItem> IdentityItems {get;set;}
        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityItem>()
               .HasKey( i=> i.Id )
               // BK added the "Property" line.
               .Property(e => e.Id)
               .HasDatabaseGeneratedOption(
                   turnOfIdentity ?
                       DatabaseGeneratedOption.None,
                       DatabaseGeneratedOption.Identity
               );
      
        }
    }
    public class IdentityItem{
        
    }
    public class AppDbContext: BaseAppDbContext{
        public AppDbContext(): base(false){}
    }
    public class AppDbContextWithIdentity : BaseAppDbContext{
        public AppDbContext(): base(true){}
    }
