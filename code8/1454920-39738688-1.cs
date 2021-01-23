     public class Twilio
    {
        //  [Key]
        public int Id { get; set; }
        public string sid { get; set; }
        public string authToken { get; set; }
        public string fromNumber { get; set; }
        public string toNumber { get; set; }
        public bool status { get; set; }
        //   [ForeignKey("userId")]
        public string userId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
