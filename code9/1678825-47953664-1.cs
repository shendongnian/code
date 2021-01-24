    public class User
    {       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //other properties
        public int CustomerId { get; set; }
    }
