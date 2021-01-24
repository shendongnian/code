        public static void getContentOfFileInDocLib(string siteUrl, string host, string sourceListName, string fileName)
        {
            siteUrl = siteUrl.EndsWith("/") ? siteUrl.Substring(0, siteUrl.Length - 1) : siteUrl;
            ClientContext context = new ClientContext(siteUrl);
            Web web = context.Site.RootWeb;
            List source = web.Lists.GetByTitle(sourceListName);
         
            context.Load(source);           
            context.Load(web);
            context.ExecuteQuery();
            FileCollection files = source.RootFolder.Files;
            Microsoft.SharePoint.Client.File file = files.GetByUrl(siteUrl + "/" + sourceListName + "/" + fileName);
            context.Load(file);
            context.ExecuteQuery();
            FileInformation fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, file.ServerRelativeUrl);
            string filePath = host + file.ServerRelativeUrl;
            System.IO.Stream fileStream = fileInfo.Stream;
            FileCreationInformation createFile = new FileCreationInformation();
            byte[] bufferByte = new byte[1024 * 100];
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            int len = 0;
            while ((len = fileStream.Read(bufferByte, 0, bufferByte.Length)) > 0)
            {
                memory.Write(bufferByte, 0, len);
            }
            //we get the content of file here
            byte[] bytes = memory.GetBuffer();
            //do something you want
            //.......
        }
