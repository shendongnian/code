    string strFilePath = @"PathToMyPDF";
    FileCreationInformation newFile = new FileCreationInformation();  
    newFile.Content = System.IO.File.ReadAllBytes(strFilePath);  
    newFile.Overwrite = true;
    SP.List targetList = ctx.Web.Lists.GetByTitle("Documents");  
    Microsoft.SharePoint.Client.File uploadFile = targetList.RootFolder.Files.Add(newFile);  
    ctx.Load(uploadFile);  
    ctx.ExecuteQuery();  
    
    uploadFile.ListItemAllFields["Title"] = "Test_title";
    uploadFile.ListItemAllFields["EAN_x0020_k_x00f3_d"] = "AnotherCodeWhichIsRequired";
    uploadFile.ListItemAllFields.Update();
    
    ctx.ExecuteQuery();  
