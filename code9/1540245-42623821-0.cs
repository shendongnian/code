    public void SendEmailMehod(string address, string subject, string body, StorageFile attactment = null)
     {
         var emailMessenger = CrossMessaging.Current.EmailMessenger;
         if (emailMessenger.CanSendEmail)
         {
             if (attactment != null)
             {
                 var email = new EmailMessageBuilder()
           .To(address)
           .Subject(subject)
           .Body(body)
           .WithAttachment(attactment)
           .Build();
                 emailMessenger.SendEmail(email);
             }
             else
             {
                 var email = new EmailMessageBuilder()
           .To(address)
           .Subject(subject)
           .Body(body)
           .Build();
                 emailMessenger.SendEmail(email);
             }
         }
     }
