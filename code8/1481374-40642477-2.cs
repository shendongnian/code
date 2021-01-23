     try
            {
                MailMessage message = new MailMessage();
                byte[] arr2 = null;
                GetMailMessage(2, ref message, ref arr2);
                message.From = new MailAddress("from@email.co.nz");
                message.To.Add("to@email.co.nz");
                message.IsBodyHtml = true;
                using (var stream = new MemoryStream(arr2))
                {
                    stream.Position = 0;
                    Attachment logo = new Attachment(stream, "Logo");
                    string contentID = "Image";
                    logo.ContentId = contentID;
                    logo.ContentDisposition.Inline = true;
                    logo.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                    message.Attachments.Add(logo);
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "MyServer";
                    smtp.Port = 25;
                    smtp.Send(message);
                    
                }
                // SaveMessage(message, arr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
