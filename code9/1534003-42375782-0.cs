            var message = await createEmail("Sent from the MailSendMailWithAttachment test.");
            var attachment = new FileAttachment();
            attachment.ODataType = "#microsoft.graph.fileAttachment";
            attachment.Name = "MyFileAttachment.txt";
            attachment.ContentBytes = Microsoft.Graph.Test.Properties.Resources.textfile;
            message.Attachments = new MessageAttachmentsCollectionPage();
            message.Attachments.Add(attachment);
            await graphClient.Me.SendMail(message, true).Request().PostAsync();
