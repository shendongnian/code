    public class UserCommentry
        {
            [Key]
            public int ID { get; set; }
            public Account Account{ get; set; }
            public virtual Account account { get; set; }
    
            public Int64 TransferID { get; set; }
        }
