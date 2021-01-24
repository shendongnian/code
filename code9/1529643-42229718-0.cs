    // Make Phone Call
    var phoneDialer = CrossMessaging.Current.PhoneDialer;
    if (phoneDialer.CanMakePhoneCall) 
        phoneDialer.MakePhoneCall("+272193343499");
    
    // Send Sms
    var smsMessenger = CrossMessaging.Current.SmsMessenger;
    if (smsMessenger.CanSendSms)
       smsMessenger.SendSms("+27213894839493", "Well hello there from Xam.Messaging.Plugin");
    
    var emailMessenger = CrossMessaging.Current.EmailMessenger;
    if (emailMessenger.CanSendEmail)
    {
        // Send simple e-mail to single receiver without attachments, bcc, cc etc.
        emailMessenger.SendEmail("to.plugins@xamarin.com", "Xamarin Messaging Plugin", "Well hello there from Xam.Messaging.Plugin");
    
        // Alternatively use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc. 
        var email = new EmailMessageBuilder()
          .To("to.plugins@xamarin.com")
          .Cc("cc.plugins@xamarin.com")
          .Bcc(new[] { "bcc1.plugins@xamarin.com", "bcc2.plugins@xamarin.com" })
          .Subject("Xamarin Messaging Plugin")
          .Body("Well hello there from Xam.Messaging.Plugin")
          .Build();
    
        emailMessenger.SendEmail(email);
    }   
