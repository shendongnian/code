    interface ISmsNotification 
    {
      int SmsId { get; }
      string SmsName { get; }
    }
    static class ISmsNotificationExtensions 
    {
      public static bool NotifySms(this ISmsNotification obj) 
      {
        var sender = new SendSMS();
        return sender.Send(obj);
      }
    }
    // ---------------------------------------------
    interface IPushNotification 
    {
      int PushAccNum { get; }
      string PushName { get; }
    }
    static class IPushNotificationExtensions 
    {
      public static bool NotifyPush(this IPushNotification obj) 
      {
        var sender = new SendEmail();
        return sender.Send(obj);
      }
    }
    // ---------------------------------------------
    interface IEmailNotification 
    {
      string EmailAddress { get; }
      string EmailPhone { get; }
    }
    static class IEmailNotificationExtensions 
    {
      public static bool NotifyEmail(this IEmailNotification obj) 
      {
        var sender = new SendEmail();
        return sender.Send(obj);
      }
    }
