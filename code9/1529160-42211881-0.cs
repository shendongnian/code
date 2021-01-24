    public class User {
      public int Id { get; set; }
      public int ServiceId { get; set; }
      public ICollection<Role> Roles { get; set; }
      public string GetFirstName(IUserBehavior behavior) => behavior.GetFirstName(this);
      //etc...
    }
