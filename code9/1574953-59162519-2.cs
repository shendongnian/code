    var hasIssues = true;
    var emoji = hasIssues ? "" : "";
	using (var client = new SmtpClient("host"))
	using (var mail = new MailMessage()) {
	    mail.From = new MailAddress("name@from.com");
		mail.To.Add("name@to.com);
		mail.Subject = $"{emoji} Emoji Test";
		mail.Body = "Did it go well?  Check the emoji on the subject line";
		client.Send(mail);
	}
