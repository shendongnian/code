    public class MyObject
    {
        [Column(Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        [Column(Order = 0)]
        [Key]
        public int ChildId { get; set; }
    
        public MyChild Child { get; set; }
    }
