    public class ApplicationUser : IdentityUser
    {
       public string Name {get;set;}  //?? missing?
       public ICollection<UserTask> OwnedUserTasks { get; set; }
       public ICollection<UserTask> ExecutedUserTasks { get; set; }
    }
