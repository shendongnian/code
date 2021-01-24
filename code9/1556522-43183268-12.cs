    public class obj4 : IEmailNotification, IPushNotification
    {
        public int PushAccNum { get; set; }
        public string PushName { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPhone { get; set; }
        public bool Notify() => this.NotifyEmail() && this.NotifyPush();
    }
