    private void button1_Click(object sender, EventArgs e)
    {
        foreach(var address in textBox2.Text.Split(","))
            SendMessage(address);
    }
    private void SendMessage(string address)
    {
        var mail = new MailMessage();
        var smtpServer = new SmtpClient(textBox5.Text);
        mail.From = new MailAddress(textBox1.Text);
		mail.To.Add(address);
		mail.Subject = textBox6.Text;
		mail.Body = textBox7.Text;
		mail.IsBodyHtml = checkBox1.Checked;
		mail.Attachments.Add(new Attachment(textBox9.Text));
		var x = int.Parse(textBox8.Text);
		smtpServer.Port = x;
		smtpServer.Credentials = new System.Net.NetworkCredential(textBox3.Text, textBox4.Text);
		smtpServer.EnableSsl = checkBox2.Checked;
		smtpServer.Send(mail);
	}
