    public class ApplicationUser : IdentityUser {
        // some custom fields
    }
    
    public class Comment{
       public int Id {get;set;}
       public string Message{get;set;}
       public DateTime Time{get;set;}
       public string AuthorId {get;set}
       [ForeignKey("AuthorId")]
       public virtual ApplicationUser Author {get;set;}
    }
    
    public class MyContext :IdentityDbContext<ApplicationUser> {
    
    public MyContext(): base("DefaultConnection", false){ }
    
       public DbSet<Comment> Comments { get; set; }
       //... other DbSets
    }
