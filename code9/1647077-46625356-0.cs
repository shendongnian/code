    //First create FileContent
    FileContentResult fileContent = File(fileName, "application/pdf", "file.pdf");
    MemoryStream ms = new MemoryStream(fileContent.FileContents); 
    // Create an in-memory System.IO.Stream
    ContentType ct = new ContentType(fileContent.ContentType);
    
    Attachment a = new Attachment(ms, ct);
    sender.SendMail("email", "email", "subject", "Body", a);
