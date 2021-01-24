    public class Sub_User{
         [Key]
         public int Sub_User_ID { get; set; }
    
         public virtual User User { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {   
        // Configure UserId as FK for Sub_User
        modelBuilder.Entity<User>()
                    .HasOptional(u => u.SubUser) 
                    .WithRequired(su => su.User);
    }
