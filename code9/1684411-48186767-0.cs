    public class WorkUser
    {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int WorkUserId { get; set; }
    
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int UserId { get; set; }
    }
