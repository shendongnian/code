    static async Task SendGridAsync()
    {
        var client = new SendGridClient("your-api-key");
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("{sender-email}", "{sender-name}"),
            Subject = "Hello World from the SendGrid CSharp SDK!",
            HtmlContent = "<strong>Hello, Email using HTML!</strong>"
        };
        var recipients = new List<EmailAddress>
        {
            new EmailAddress("{recipient-email}", "{recipient-name}")
        };
        msg.AddTos(recipients);
        string CalendarContent = MeetingRequestString("{ORGANIZER}", new List<string>() { "{ATTENDEE}" },"{subject}","{description}", "{location}", DateTime.Now, DateTime.Now.AddDays(2));
        byte[] calendarBytes = Encoding.UTF8.GetBytes(CalendarContent.ToString());
        SendGrid.Helpers.Mail.Attachment calendarAttachment = new SendGrid.Helpers.Mail.Attachment();
        calendarAttachment.Filename = "invite.ics";
        //the Base64 encoded content of the attachment.
        calendarAttachment.Content = Convert.ToBase64String(calendarBytes);
        calendarAttachment.Type = "text/calendar";
        msg.Attachments = new List<SendGrid.Helpers.Mail.Attachment>() { calendarAttachment };
        var response = await client.SendEmailAsync(msg);
    }
    private static string MeetingRequestString(string from, List<string> toUsers, string subject, string desc, string location, DateTime startTime, DateTime endTime, int? eventID = null, bool isCancel = false)
    {
        StringBuilder str = new StringBuilder();
        str.AppendLine("BEGIN:VCALENDAR");
        str.AppendLine("PRODID:-//Microsoft Corporation//Outlook 12.0 MIMEDIR//EN");
        str.AppendLine("VERSION:2.0");
        str.AppendLine(string.Format("METHOD:{0}", (isCancel ? "CANCEL" : "REQUEST")));
        str.AppendLine("BEGIN:VEVENT");
        str.AppendLine(string.Format("DTSTART:{0:yyyyMMddTHHmmssZ}", startTime.ToUniversalTime()));
        str.AppendLine(string.Format("DTSTAMP:{0:yyyyMMddTHHmmss}", DateTime.Now));
        str.AppendLine(string.Format("DTEND:{0:yyyyMMddTHHmmssZ}", endTime.ToUniversalTime()));
        str.AppendLine(string.Format("LOCATION: {0}", location));
        str.AppendLine(string.Format("UID:{0}", (eventID.HasValue ? "blablabla" + eventID : Guid.NewGuid().ToString())));
        str.AppendLine(string.Format("DESCRIPTION:{0}", desc.Replace("\n", "<br>")));
        str.AppendLine(string.Format("X-ALT-DESC;FMTTYPE=text/html:{0}", desc.Replace("\n", "<br>")));
        str.AppendLine(string.Format("SUMMARY:{0}", subject));
        str.AppendLine(string.Format("ORGANIZER;CN=\"{0}\":MAILTO:{1}", from, from));
        str.AppendLine(string.Format("ATTENDEE;CN=\"{0}\";RSVP=TRUE:mailto:{1}", string.Join(",", toUsers), string.Join(",", toUsers)));
        str.AppendLine("BEGIN:VALARM");
        str.AppendLine("TRIGGER:-PT15M");
        str.AppendLine("ACTION:DISPLAY");
        str.AppendLine("DESCRIPTION:Reminder");
        str.AppendLine("END:VALARM");
        str.AppendLine("END:VEVENT");
        str.AppendLine("END:VCALENDAR");
        return str.ToString();
    }
