    using (IO.FileStream fs = new IO.FileStream(tempDocx, IO.FileMode.Open))
    {
        List documentsList = clientContext.Web.Lists.GetByTitle(libTitle);
        clientContext.Load(documentsList.RootFolder);
        clientContext.ExecuteQuery();
        var fileCreationInformation = new FileCreationInformation();
        //Assign to content byte[] i.e. documentStream
        fileCreationInformation.ContentStream = fs;
        //Allow owerwrite of document
        fileCreationInformation.Overwrite = true;
        //Upload URL
        fileCreationInformation.Url = documentsList.RootFolder.ServerRelativeUrl + "/" + IO.Path.GetFileName(tempDocx);
        uploadFile = documentsList.RootFolder.Files.Add(fileCreationInformation);
        clientContext.Load(uploadFile);
        clientContext.ExecuteQuery();
    }
