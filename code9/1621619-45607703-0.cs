    protected void Button1_Click(object sender, EventArgs e)
    {
        //create an email
        MailMessage message = new MailMessage();
        message.From = new MailAddress("your@email.com", "MyCompany");
        message.Subject = "Email subject goes here";
        message.IsBodyHtml = true;
        message.Body = "<html><head></head><body><font size=\"3\" color=\"#ff0000\">HTML formatted email body.</body></html>";
        //add the attachment
        message.Attachments.Add(new Attachment(Server.MapPath("test.pdf")));
        //get the message as byte array
        byte[] bin = getEmailAsEML(message);
        //send the email to the client as eml
        Response.ClearHeaders();
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "message/rfc822";
        Response.AddHeader("content-length", bin.Length.ToString());
        Response.AddHeader("content-disposition", "attachment; filename=\"email.eml\"");
        Response.OutputStream.Write(bin, 0, bin.Length);
        Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
    public byte[] getEmailAsEML(MailMessage message)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            var binaryWriter = new BinaryWriter(ms);
            //Write the Unsent header to the file so the mail client knows this mail must be presented in "New message" mode
            binaryWriter.Write(Encoding.UTF8.GetBytes("X-Unsent: 1" + Environment.NewLine));
            var assembly = typeof(SmtpClient).Assembly;
            var mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");
            // Get reflection info for MailWriter contructor
            var mailWriterContructor = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);
            // Construct MailWriter object with our FileStream
            var mailWriter = mailWriterContructor.Invoke(new object[] { ms });
            // Get reflection info for Send() method on MailMessage
            var sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);
            sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { mailWriter, true, true }, null);
            // Finally get reflection info for Close() method on our MailWriter
            var closeMethod = mailWriter.GetType().GetMethod("Close", BindingFlags.Instance | BindingFlags.NonPublic);
            // Call close method
            closeMethod.Invoke(mailWriter, BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { }, null);
            return ms.ToArray();
        }
    }
