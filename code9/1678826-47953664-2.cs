    public class User
    {       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //other properties
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
