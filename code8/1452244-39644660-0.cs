    public class Notification
    {
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        [InverseProperty("SentNotifications")]
        public virtual SystemUser FromUser { get; set; }
        [InverseProperty("RecievedNotifications")]
        public virtual SystemUser ToUser { get; set; }
    }
