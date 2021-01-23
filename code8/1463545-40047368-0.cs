    public class UserDatabase
    {
        [Key, Column(Order=0)]
        public int UserID { get; set; }
    
        [ForeignKey("UserID")]
        public virtual User Users{ get; set; }
    
        [Key, Column(Order=1)]
        public int DatabaseID { get; set; }
    
        [ForeignKey("DatabaseID")]
        public virtual Database Database { get; set; }
    }
