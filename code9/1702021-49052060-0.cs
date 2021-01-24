           public Microsoft.Sharepoint.Client.File Upload()
        {
            ClientResult<long> bytesUploaded = null;
    
            FileStream fs = null;
            try
            {
    
                int blockSize = 8000000; // 8 MB
    
                string uniqueFileName = String.Empty;
                long fileSize;
                Microsoft.SharePoint.Client.File uploadFile = null;
                Guid uploadId = Guid.NewGuid();
    
                string userName = "your Username";
                string pwd = "your password";
    
                string fileName = Convert.ToString(FileUpload1.PostedFile.FileName);
    
    
                using (ClientContext ctx = new ClientContext("site url"))
                {
    
                    SecureString passWord = new SecureString();
                    foreach (char c in pwd.ToCharArray()) passWord.AppendChar(c);
    
                    ctx.Credentials = new SharePointOnlineCredentials(userName, passWord);
                    List docs = ctx.Web.Lists.GetByTitle("Documents");
                    ctx.Load(docs.RootFolder, p => p.ServerRelativeUrl);// ServerUrl provide you with the same Server relative path of a document inside a document library
    
                    // Use large file upload approach
    
    
                    fs = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    
                    fileSize = fs.Length;
    
    
     fileSize = fs.Length;
                        if (fileSize <= blockSize)
                        {
                            blockSize = Convert.ToInt32(fileSize) - 1;//the file size should be less for the if condition with last slice to run.
                        }
                    uniqueFileName = System.IO.Path.GetFileName(fs.Name);
    
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] buffer = new byte[blockSize];
                        byte[] lastBuffer = null;
                        long fileoffset = 0;
                        long totalBytesRead = 0;
                        int bytesRead;
                        bool first = true;
                        bool last = false;
    
                        // Read data from filesystem in blocks
                        while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            totalBytesRead = totalBytesRead + bytesRead;
    
                            // We've reached the end of the file
                            if (totalBytesRead <= fileSize)
                            {
                                last = true;
                                // Copy to a new buffer that has the correct size
                                lastBuffer = new byte[bytesRead];
                                Array.Copy(buffer, 0, lastBuffer, 0, bytesRead);
                            }
    
                            if (first)
                            {
                                using (MemoryStream contentStream = new MemoryStream())
                                {
                                    // Add an empty file.
                                    FileCreationInformation fileInfo = new FileCreationInformation();
                                    fileInfo.ContentStream = contentStream;
                                    fileInfo.Url = uniqueFileName;
                                    fileInfo.Overwrite = true;
                                    uploadFile = docs.RootFolder.Files.Add(fileInfo);
    
                                    // Start upload by uploading the first slice.
                                    using (MemoryStream s = new MemoryStream(buffer))
                                    {
                                        // Call the start upload method on the first slice
                                        bytesUploaded = uploadFile.StartUpload(uploadId, s);
                                        ctx.ExecuteQuery();
                                        // fileoffset is the pointer where the next slice will be added
                                        fileoffset = bytesUploaded.Value;
                                    }
    
                                    // we can only start the upload once
                                    first = false;
                                }
                            }
                            else
                            {
                                // Get a reference to our file
                                uploadFile = ctx.Web.GetFileByServerRelativeUrl(docs.RootFolder.ServerRelativeUrl + System.IO.Path.AltDirectorySeparatorChar + uniqueFileName);
    
                                if (last==true && totalBytesRead >= fileSize)
                                {
                                    // Is this the last slice of data?
                                    using (MemoryStream s = new MemoryStream(lastBuffer))
                                    {
                                        // End sliced upload by calling FinishUpload
                                        uploadFile = uploadFile.FinishUpload(uploadId, fileoffset, s);
                                        ctx.ExecuteQuery();
    
                                        // return the file object for the uploaded file
                                      return uploadFile;
                                    }
                                }
                                else
                                {
                                    using (MemoryStream s = new MemoryStream(buffer))
                                    {
                                        // Continue sliced upload
                                        bytesUploaded = uploadFile.ContinueUpload(uploadId, fileoffset, s);
                                        ctx.ExecuteQuery();
                                        // update fileoffset for the next slice
                                        fileoffset = bytesUploaded.Value;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
    
                }
            }
        }
