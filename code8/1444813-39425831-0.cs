    public class Child
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
    
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParentID { get; set; }
        [ForeignKey("ParentID")]
        public Parent Parent { get; set; }
    }
