	private string ConvertXlsToHtml(IWorkbook workbook)
	{
		ExcelToHtmlConverter excelToHtmlConverter = new ExcelToHtmlConverter();
		// Set output parameters 
		excelToHtmlConverter.OutputColumnHeaders = false;
		excelToHtmlConverter.OutputHiddenColumns = true;
		excelToHtmlConverter.OutputHiddenRows = true;
		excelToHtmlConverter.OutputLeadingSpacesAsNonBreaking = false;
		excelToHtmlConverter.OutputRowNumbers = true;
		excelToHtmlConverter.UseDivsToSpan = true;
		// Process the Excel file 
		excelToHtmlConverter.ProcessWorkbook(workbook);
								
		return excelToHtmlConverter.Document.ToString();
	}
	....
	using (var ms = new MemoryStream())
	{
		workbook.Write(ms);
		ms.Position = 0;
		string mailBody = getHTML(data) + ConvertXlsToHtml(workbook);
		
		using (MailMessage mm = new MailMessage())
		{
			mm.From = new MailAddress("abcd@gmail.com");
			mm.Bcc.Add("abcd@gmail.com");
			SmtpClient smtp = new SmtpClient();
			mm.Subject = "Task List";
			StringBuilder sb = new StringBuilder();
			mm.Body = mailBody;
			mm.Attachments.Add(new Attachment(ms, "Task.xls", "application/vnd.ms-excel"));
			mm.IsBodyHtml = true;
			smtp.Host = "smtp.gmail.com";
			smtp.EnableSsl = true;
			System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
			credentials.UserName = "abc@gmail.com";
			credentials.Password = "1234";
			smtp.UseDefaultCredentials = true;
			smtp.Credentials = credentials;
			smtp.Port = 587;
			smtp.Send(mm);
		}
	}
