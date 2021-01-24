     public class Types
     {
      public string Id { get; set; }
      public string Sum { get; set; }
      public string Addition { get; set; }
      public string Email { get; set; }
    
      public Types(Access access)
        {
          Email = access.Email
        }
     }
