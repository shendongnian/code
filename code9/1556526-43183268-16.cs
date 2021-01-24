    interface ISmsNotifier
    {
      int SmsId { get; }
      string SmsName { get; }
    }
    static class ISmsNotifierExtensions 
    {
      public static bool NotifySms(this ISmsNotifier obj) 
      {
        var sender = new SendSMS();
        return sender.Send(obj);
      }
    }
    // ---------------------------------------------
    interface IPushNotifier 
    {
      int PushAccNum { get; }
      string PushName { get; }
    }
    static class IPushNotifierExtensions 
    {
      public static bool NotifyPush(this IPushNotifier obj) 
      {
        var sender = new SendEmail();
        return sender.Send(obj);
      }
    }
    // ---------------------------------------------
    interface IEmailNotifier 
    {
      string EmailAddress { get; }
      string EmailPhone { get; }
    }
    static class IEmailNotifierExtensions 
    {
      public static bool NotifyEmail(this IEmailNotifier obj) 
      {
        var sender = new SendEmail();
        return sender.Send(obj);
      }
    }
