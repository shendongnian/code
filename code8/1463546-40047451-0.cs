    public class UserDatabase
    {
        [ForeignKey("Users")]
        public int UserID { get; set; }
    
        [ForeignKey("Database")]
        public int DatabaseID { get; set; }
    
        public virtual User Users{ get; set; }
        public virtual Database Database { get; set; }
    }
