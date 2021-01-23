    public class Project
    {
       //other properties
       
       //FYI, EF by a name convention will use this property as FK,
       //but is a good practice specify explicitly which is the FK in a relationship 
       [ForeignKey("User")]
       public int UserId{get;set;}
    
       public virtual User User{get;set;}
    }
