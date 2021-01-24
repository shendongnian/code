    public class MyCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public int MyCategoryId { get; set; }
    
        public List<MyItem> Items { get; set; }
    }
    
   
    public class MyItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public int MyCategoryId { get; set; }
    
        public string ItemsContents { get; set; }
        [ForeignKey("MyCategoryId")]
        public virtual MyCategory MyCategory { get; set; }
    }
