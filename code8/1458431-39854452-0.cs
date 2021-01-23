    public class MyContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             if(UsingSqlLite)
             {
                 modelBuilder.Entity<Site>().ToTable("Sites");
             }
             else
             {
                 modelBuilder.Entity<Site>().ToTable("Sites", "Common");
             }
        } 
        //snip
    }
