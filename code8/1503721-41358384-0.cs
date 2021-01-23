    public class MyApplicationDbContext : DbContext 
      {
         public MyApplicationDbContext()
             : base("your_connection_name")
         {
         }
    
         public static MyApplicationDbContext Create()
         {
             return new MyApplicationDbContext();
         } 
      }
