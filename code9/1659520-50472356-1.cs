        static private void CopyFile()
        {
            ClientContext contextOrigin = new ClientContext(originSiteURL);
            ClientContext contextDestination = new ClientContext(destinationSiteURL);
            contextOrigin.Credentials = new SharePointOnlineCredentials(originUser, originSecurePassword);
            contextDestination.Credentials = new SharePointOnlineCredentials(destinationUser, destinationSecurePassword);
            //Grab File
            FileInformation fileInformation = Microsoft.SharePoint.Client.File.OpenBinaryDirect(contextOrigin, "/path/to/Document.docx"); //Server relative url
            contextOrigin.ExecuteQuery();
            //Read Stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                CopyStream(fileInformation.Stream, memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                //Create Copy
                var fileCreationInfo = new FileCreationInformation
                {
                    ContentStream = memoryStream,
                    Overwrite = true,
                    Url = Path.Combine("path/to/", "CopiedDocument.docx")
                };
                var uploadFile = contextDestination.Web.RootFolder.Files.Add(fileCreationInfo);
                contextDestination.Load(uploadFile);
                contextDestination.ExecuteQuery();
            }
        }
