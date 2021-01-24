    public class obj1 : INotifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Notify()
        {
            var sender = new SendSMS();
            return sender.Send(this);
        }
    }
    public class obj2 : INotifier
    {
        public int AccNum { get; set; }
        public string Name { get; set; }
        public bool Notify()
        {
            var sender = new SendPush();
            return sender.Send(this);
        }
    }
    public class obj3 : INotifier
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Notify()
        {
            var sender = new SendEmail();
            return sender.Send(this);
        }
    }
