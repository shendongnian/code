     public static MailMessage BuildEnqNotificationMessage(string _To, string _Body)
        {
            MailMessage Msg = new MailMessage();
            Msg.From = new MailAddress(FromAddress, FromFriendly);
            Msg.Subject = "New Sales Enquiry";
            Msg.To.Add(_To);
            Msg.Body = _Body;
            Msg.IsBodyHtml = true;
            return Msg;
        }
