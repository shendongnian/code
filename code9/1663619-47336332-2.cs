    public class UserTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTaskID { get; set; }
        public string Description { get; set; }
        public ApplicationUser ApplicationUser {get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
       public ICollection<UserTask> UserTask { get; set; }
    }
