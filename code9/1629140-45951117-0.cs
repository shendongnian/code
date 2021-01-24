    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int MagazineId { get; set; }
        public int ReaderId { get; set; }
        [ForeignKey("MagazineId")]
        public Magazine Magazine { get; set; }
        [ForeignKey("ReaderId")]
        public Reader Reader { get; set; }
    }
