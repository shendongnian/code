    private string GetSenderSMTPAddress(Outlook.MailItem mail)
    {
        string PR_SMTP_ADDRESS =
           @"http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
        if (mail == null)
        {
            throw new ArgumentNullException();
        }
        if (mail.SenderEmailType == "EX")
        {
           Outlook.AddressEntry sender =
              mail.Sender;
           if (sender != null)
           {
               //Now we have an AddressEntry representing the Sender
               if (sender.AddressEntryUserType ==
                   Outlook.OlAddressEntryUserType.olExchangeUserAddressEntry
                   || sender.AddressEntryUserType ==                    Outlook.OlAddressEntryUserType.olExchangeRemoteUserAddressEntry)
               {
                   //Use the ExchangeUser object PrimarySMTPAddress
                   Outlook.ExchangeUser exchUser =
                       sender.GetExchangeUser();
                   if (exchUser != null)
                   {
                       return exchUser.PrimarySmtpAddress;
                   }
                   else
                   {
                       return null;
                   }
               }
               else
               {
                   return sender.PropertyAccessor.GetProperty(
                       PR_SMTP_ADDRESS) as string;
               }
           }
           else
           {
               return null;
           }
       }
       else
       {
           return mail.SenderEmailAddress;
       }
    }
