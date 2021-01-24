    public class UserPost
    {  
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; } // change to numeric data type
       public string PostTitle { get; set; }
       public virtual UserProfile UserProfile { get; set; }
       public string Contents { get; set; }
    }
