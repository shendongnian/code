    var filePath = @"C:\PATH_TO_FILE\test.docx";
    
    using (var context = new ClientContext("YOUR_SITE_URL") { Credentials = credentials })
    {
        var folder = context.Web.GetFolderByServerRelativeUrl("/sites/YOUR_SITE/LIBRARY_INTERNAL_NAME/FOLDER_NAME");
        context.Load(folder);
        context.ExecuteQuery();
        folder.Files.Add(new FileCreationInformation
        {
            Overwrite = true,
            Content = System.IO.File.ReadAllBytes(filePath),
            Url = Path.GetFileName(filePath)
        });
        context.ExecuteQuery();
    }
