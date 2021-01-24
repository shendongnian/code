    public class UserLike // Child
    {
        public int Id { get; set; }
        public long UserId { get; set; } // Foreign key
        public virtual User User { get; set; } // Navigation property
    }
