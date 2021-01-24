        foreach (var file in Directory.GetFiles(programFilesDataDir))
        {
            attachments = new Attachment(file, MediaTypeNames.Application.Pdf);
            message.Attachments.Add(attachments);           
        }
        if(attachments.Count > 0)
            client.Send(message);
