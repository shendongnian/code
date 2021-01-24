    interface ISmsNotification 
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
    interface IPushNotification 
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
    interface IEmailNotification 
    {
      string EmailAddress { get; }
      string EmailPhone { get; }
      public bool NotifyEmail() 
      {
        var sender = new SendEmail();
        return sender.Send(this);
      }
    }
