           // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            
            var file = new Attachment(FileLocation);
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.Attachments.Add(file);
            msg.Body = "Tester Body";
            msg.To.Add("MyTestDestinationEmailAddress@Gmail.com");
            MimeMessage messageMIME = MimeMessage.CreateFromMailMessage(msg); //using MimeKit here
             MemoryStream memory = new MemoryStream();
            messageMIME.WriteTo(memory);
            Draft draft = new Draft();
            var createRequest = service.Users.Drafts.Create(draft, "me", memory, @"message/rfc822");
            
            var startTime = Stopwatch.StartNew();
            var uploadProgress = createRequest.Upload();
            
            if (uploadProgress.Status == UploadStatus.Completed)
            {
                Debug.WriteLine(String.Format("Elapsed Time: {0}", startTime.Elapsed));
                Debug.WriteLine(String.Format("Status: {0}", uploadProgress.Status.ToString()));
                Debug.WriteLine(String.Format("Bytes Sent: {0}", uploadProgress.BytesSent));
                //to send the draft email, uncomment the lines below
                //draft = createRequest.ResponseBody;
                //var send =  service.Users.Drafts.Send(draft, "me");
                //send.Execute();
            }
            else
            {
                Debug.WriteLine(String.Format("Exception: {0}", uploadProgress.Exception.Message));
            }
