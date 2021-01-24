	using (MailMessage Message = new MailMessage())
	{
		Message.From = new MailAddress("from@mail.com");
		Message.Subject = "My Subject";
		Message.Body = "My Body";
		Message.To.Add(new MailAddress("to@mail.com"));
		//Attach more file
		foreach (var item in Attachment)
		{
			MemoryStream ms = new MemoryStream(File.ReadAllBytes(filePath));
			Attachment Data = new Attachment(ms, "FileName");
			ContentDisposition Disposition = Data.ContentDisposition;
			Disposition.CreationDate = DateTime.UtcNow.AddHours(-5);
			Disposition.ModificationDate = DateTime.UtcNow.AddHours(-5);
			Disposition.ReadDate = DateTime.UtcNow.AddHours(-5);
			Data.ContentType = new ContentType(MediaTypeNames.Application.Pdf);
			Message.Attachments.Add(Data);
		}
		SmtpClient smtp = new SmtpClient("SmtpAddress", "SmtpPort");
		smtp.Credentials = new NetworkCredential("SmtpUser", "SmtpPassword");
		await smtp.SendMailAsync(Message);
	}
