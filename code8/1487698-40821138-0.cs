    public class ApplicationUser : IdentityUser 
    {
        //Other Properties
        public ICollection<Tag> StudyTags { get; set; }
        public ICollection<Tag> ExpertTags { get; set; }
    }
    
    public class Tag
    {
        //Other Properties
        public ICollection<ApplicationUser> Users { get; set; }
    }
    
    public class UserTags 
    {
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
