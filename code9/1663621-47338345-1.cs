    public class ApplicationUser : IdentityUser
    {
       public ICollection<UserTask> OwnedUserTasks { get; set; }
       public ICollection<UserTask> ExecutedUserTasks { get; set; }
    }
