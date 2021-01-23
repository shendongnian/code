    string emailList = "thisemail@gmail.com,hello@yahoo.it,YesOrNo@gmail.com";
    string[] emails = emailList.Split(","); // replace this text with your source :)
    
    foreach(string s in emails)
    {
    var mail = new MailMessage();
                var smtpServer = new SmtpClient(textBox5.Text);
                mail.From = new MailAddress(textBox1.Text);
                mail.To.Add(s);
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
