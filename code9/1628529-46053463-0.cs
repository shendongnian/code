    public class Item 
    {
       public int Id {get; set;}
       public string Name {get; set;}
       //foreign key
       public int UserId {get; set;}
       //Navigation property 
       public virtual ApplicationUser User{get; set;}
    }
