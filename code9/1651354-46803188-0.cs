    using System.Data.Entity;  
    using System.Data.Entity.ModelConfiguration.Conventions;  
    using Votes.Models;  
    namespace vote.Context  
    {  
        public class DatabaseContext : DbContext  
        {  
            public DatabaseContext() : base("VotesDatabase")  
            { }  
            public DbSet<Vote> Votes{ get; set; }  
            protected override void OnModelCreating(DbModelBuilder modelBuilder)  
            {  
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  
            }  
        }  
    } 
