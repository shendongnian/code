    public class CommunityUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? CustomerId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int ForumPostsNumber { get; set; }
        public virtual Customer Customer { get; set; }
    }
