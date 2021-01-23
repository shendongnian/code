    public class User
    {
        [Key]
        public System.Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<CommentToReview> Comments { get; set; }
        public virtual ICollection<UserToReview> Reviews { get; set; }
    }
    public class Review
    {
       [Key]
       public System.Guid Id { get; set; }
       public System.Guid CreatorUserId { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }
       public System.DateTime CreatedDate { get; set; }
       public int UserRating { get; set; }
       public int LikeCount { get; set; }
       public int DislikeCount { get; set; }
       public virtual ICollection<CommentToReview> Comments { get; set; }
       public virtual ICollection<UserToReview> Users { get; set; }
    }
    public class CommentToReview
    {
        [Key]
        public System.Guid Id { get; set; }
        [ForeignKey("User")]
        public System.Guid UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Review")]
        public System.Guid ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public string Comment { get; set; }
        public System.DateTime CreatedDate { get; set; } 
    }
    public class UserToReview
    {
        [Key]
        public System.Guid Id { get; set; }
        [ForeignKey("User")]
        public System.Guid UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Review")]
        public System.Guid ReviewId { get; set; }
        public virtual Review Review { get; set; }
        public bool HasLiked { get; set; }
    }
