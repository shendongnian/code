    public class Author
    {
        public Author()
        {
        }
    
        [Key]
        public int Auth_Id { get; set; }
        [StringLength(100)]
        public string First_Name { get; set; }  
    
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [StringLength(100)]
        public string Last_Name { get; set; }
    
        public string Biography { get; set; }
    }
