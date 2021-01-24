    HttpPostedFile attachAdd = page.Request.Form["attachAdd"];
    var email = new MailMessage();
    string strFileName =
            System.IO.Path.GetFileName(attachAdd.PostedFile.FileName);
            Attachment attachFile =
            new Attachment(attachAdd.PostedFile.InputStream, strFileName);
            email.Attachments.Add(attachFile);
