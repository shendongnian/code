    try
            {
                MailMessage message = new MailMessage();
                var logoPath = @"C:\MyLogo.jpg";
                message.From = new MailAddress("from@email.co.nz");
                message.To.Add("to@email.co.nz");
                message.IsBodyHtml = true;
                //Read the attachment into byte Array. This assumes single attachment only in the Mail Message.
                byte[] arr = File.ReadAllBytes(logoPath);
                using (var stream = new MemoryStream(arr))
                {
                    stream.Position = 0;
                    Attachment logo = new Attachment(stream, "Logo");
                    string contentID = "Image";
                    logo.ContentId = contentID;
                    logo.ContentDisposition.Inline = true;
                    logo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    string wsHdr = "<html><body><p><a href=\"http://www.tecnq.com.au\" target=\"_blank\"><img alt=\"tecnqlogo\" src=\"cid:" + contentID + "\" style=\"border-style:none; height:34px; width:100px\" /></a></p>" + "</html></body>"; ;
                    message.Body = wsHdr;
                    message.Attachments.Add(logo);
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "MyServer";
                    smtp.Port = 25;
                    smtp.Send(message);
                    SaveMessage(message, arr);
                }             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
