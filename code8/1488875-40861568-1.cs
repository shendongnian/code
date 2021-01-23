	public void SendData(string server, string recipientList)
	{
	    //Same as before
	    using (ExcelPackage package = new ExcelPackage())
	    {
	        var ws = package.Workbook.Worksheets.Add("My Sheet");
	        ws.Cells["A1"].LoadFromDataTable(dataTable, true);
	        var stream = new MemoryStream();
	        package.SaveAs(stream);
	        string fileName = "myfilename.xlsx";
	        string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
	        stream.Position = 0;
            SendExcel(server,recipientList);
        }
    }
    void SendExcel(string server, string recipientList)
    {
            //Send the file
            var message = new MailMessage("logMailer@contoso.com", recipientList);
            message.Subject = "Some Data";
            Attachment data = new Attachment(stream, name, contentType);
            // Add the attachment to the message.
            message.Attachments.Add(data);
            // Send the message.
            // Include credentials if the server requires them.
            var client = new SmtpClient(server);
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.Send(message);
	    }
	}
