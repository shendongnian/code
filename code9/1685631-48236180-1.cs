        foreach (var file in files))
        {
            attachments = new Attachment(file, MediaTypeNames.Application.Pdf);
            message.Attachments.Add(attachments);           
        }
        client.Send(message);
