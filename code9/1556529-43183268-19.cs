    interface ISmsNotifier 
    {
      int SmsId { get; }
      string SmsName { get; }
      public bool NotifySms() 
      {
        var sender = new SendSMS();
        return sender.Send(this);
      }
    }
    // ---------------------------------------------
    interface IPushNotifier 
    {
      int PushAccNum { get; }
      string PushName { get; }
      public bool NotifyPush() 
      {
        var sender = new SendEmail();
        return sender.Send(this);
      }
    }
    // ---------------------------------------------
    interface IEmailNotifier 
    {
      string EmailAddress { get; }
      string EmailPhone { get; }
      public bool NotifyEmail() 
      {
        var sender = new SendEmail();
        return sender.Send(this);
      }
    }
