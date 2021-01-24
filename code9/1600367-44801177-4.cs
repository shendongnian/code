	HSSFWorkbook workbook = CreateWorkbook();
	string excelEmbedded = string.Empty;
	using (MemoryStream ms = new MemoryStream())
	{
		workbook.Write(ms);
		ms.Position = 0;
		excelEmbedded = ConvertExcelToHTML(workbook);
	}
	using (MailMessage message = new MailMessage())
	{
		message.Body = GetHTML().Replace("{excel}", excelEmbedded);
		message.Subject = "Embedded Excel";
		message.From = new MailAddress("abcd@gmail.com");
		message.To.Add("abc@gmail.com");
		message.IsBodyHtml = true;
		using (SmtpClient client = new SmtpClient())
		{
			NetworkCredential credentials = new NetworkCredential();
			credentials.UserName = "abc@gmail.com";
			credentials.Password = "1234";
			client.Host = "smtp.gmail.com";
			client.UseDefaultCredentials = true;
			client.Credentials = credentials;
			client.Port = 587;
			client.Send(message);
		}
	}
