    public class UserTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserTaskID { get; set; }
        public string Description { get; set; }
        [ForeignKey("OwnerUserID")]
        public string TaskOwnerId { get; set; }
        [ForeignKey("ExecutorUserID")]
        public string TaskExecutorId { get; set; }
        public virtual ApplicationUser OwnerUserID { get; set; }
        public virtual ApplicationUser ExecutorUserID { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
       [ForeignKey("UserTaskID")]
       public int UserTaskID { get; set; }
       public UserTask UserTask { get; set; }
    }
