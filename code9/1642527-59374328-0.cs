    public class User // Parent
    {
        public long Id { get; set; }
        public virtual ICollection<UserLike> UserLikes { get; set; } // Child collection
    }
    
    public class UserLike // Child
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key
        public virtual User User { get; set; } // Navigation property
    }
