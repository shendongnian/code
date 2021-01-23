            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            //we don't add the attachment to the message here anymore
            //msg.Attachments.Add(file);
            msg.Body = "Tester Body";
            MimeMessage messageMIME = MimeMessage.CreateFromMailMessage(msg); //using MimeKit here
             MemoryStream memory = new MemoryStream();
            messageMIME.WriteTo(memory);
            Google.Apis.Gmail.v1.Data.Message m = new Google.Apis.Gmail.v1.Data.Message();
            m.Raw = Convert.ToBase64String(memory.ToArray()); //private method for Convert.ToBase64String
            
            Draft draft = new Draft();
            draft.Message = m;
            //here we create an instance of the draft, WITHOUT THE ATTACHMENT first
            var createRequest = service.Users.Drafts.Create(draft, "me");
            var createdDraft = createRequest.Execute();
            Attachment file = new Attachment(FileLocation);
            //since we already have the draft in gmail servers at this point, we need only to create an update request to the previous draft
            var updateRequest = service.Users.Drafts.Update(draft, "me", createdDraft.Id, file.ContentStream,
                @"message/rfc822");
            var startTime = Stopwatch.StartNew();
            var uploadProgress = updateRequest.Upload();
            if (uploadProgress.Status == UploadStatus.Completed)
            {
                Debug.WriteLine(String.Format("Elapsed Time: {0}", startTime.Elapsed));
                Debug.WriteLine(String.Format("Status: {0}", uploadProgress.Status.ToString()));
                Debug.WriteLine(String.Format("Bytes Sent: {0}", uploadProgress.BytesSent));
            }
            else
            {
                Debug.WriteLine(String.Format("Exception: {0}", uploadProgress.Exception.Message));
            }
