    public class obj1 : INotifier, ISmsNotifier 
    {
      public int SmsId { get; set; }
      public string SmsName { get; set; }
      public bool Notify() => this.NotifySms();
    }
    public class obj2 : INotifier, IPushNotifier
    {
        public int PushAccNum { get; set; }
        public string PushName { get; set; }
        public bool Notify() => this.NotifyPush();
    } 
    public class obj3 : INotifier, IEmailNotifier
    {
        public string EmailAddress { get; set; }
        public string EmailPhone { get; set; }
        public bool Notify() => this.NotifyEmail();
    }
