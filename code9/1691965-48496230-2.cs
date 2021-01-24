        public static void uploadFile(string siteUrl, string filePath, string fileName, string docLibName)
        {
            siteUrl = siteUrl.EndsWith("/") ? siteUrl.Substring(0, siteUrl.Length - 1) : siteUrl;           
            ClientContext context = new ClientContext(siteUrl);
            List docLib = context.Web.Lists.GetByTitle(docLibName);
            context.Load(docLib);
            context.ExecuteQuery();
            Byte[] bytes = System.IO.File.ReadAllBytes(filePath + fileName);
            FileCreationInformation createFile = new FileCreationInformation();
            createFile.Content = bytes;
            createFile.Url = siteUrl + "/" + docLibName + "/" + fileName;
            createFile.Overwrite = true;
            Microsoft.SharePoint.Client.File newFile = docLib.RootFolder.Files.Add(createFile);
            newFile.ListItemAllFields.Update();
            context.ExecuteQuery();
        }
