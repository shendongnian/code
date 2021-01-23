    //...other code
    var attachments = new List<string>();
    var attachmentsNames = new List<string>();
    var file = order.file1;
    if (file.ContentLength > 0) {
        var fileName = Path.GetFileName(file.FileName);
        var filePath = Path.Combine(Server.MapPath("~/App_Data/attachments"), fileName);
        file.SaveAs(filePath);//save the file to disk
        //add file path and name to collections.
        attachments.Add(filePath);
        attachmentsNames.Add(fileName);        
    }
    //...other code
