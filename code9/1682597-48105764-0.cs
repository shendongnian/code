    public class IncomingCheckHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Key]
        public string LongDescription { get; set; }
    }
