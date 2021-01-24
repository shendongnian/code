    [Table("ConferenceLogin")]
    public class Login
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long confid { get; set; }
        [Key, Column(Order = 1)]
        public string emailID { get; set; }       
        [Key, Column(Order = 2)]
        public string registration { get; set; }
        [Key, Column(Order = 3)]
        public long regNo { get; set; }        
    }
