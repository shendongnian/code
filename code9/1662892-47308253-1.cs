    var fileInfo = new FileCreationInformation();
    fileInfo.Content = System.IO.File.ReadAllBytes(filePath);
    fileInfo.Url = Path.GetFileName(filePath);
    var list = ctx.Web.Lists.GetByTitle(listTitle);
    var uploadFile = list.RootFolder.Files.Add(fileInfo);
    ctx.Load(uploadFile.ListItemAllFields,item => item["EncodedAbsUrl"], item => item["FileRef"]);
    ctx.ExecuteQuery();
    Console.WriteLine(uploadFile.ListItemAllFields["EncodedAbsUrl"]);
    Console.WriteLine(uploadFile.ListItemAllFields["FileRef"]);
