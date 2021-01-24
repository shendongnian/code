    string tempEmail = Path.ChangeExtension(Path.GetTempFileName(), "eml");
    string tempImage = Path.Combine(Path.GetTempPath(), "Attachment.jpg");
    pictureBox1.Image.Save(tempImage, ImageFormat.Jpeg);
    var mailMessage = new MailMessage("from@domain.com", "to@domain.com", "Subject here", "Body text here");
    mailMessage.Attachments.Add(new Attachment(tempImage));
    mailMessage.Save(tempEmail);
    Process.Start(tempEmail);
