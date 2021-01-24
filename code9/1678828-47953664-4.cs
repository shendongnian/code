    public class User
    {       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //other properties
        [ForeignKey("CustomerIdA")]
        public Customer CustomerA { get; set; }
        public int CustomerIdA { get; set; }
        [ForeignKey("CustomerIdB")]
        public Customer CustomerB { get; set; }
        public int CustomerIdB { get; set; }
    }
