     public void ProcessRequest(HttpContext content)
            {
                if (content.Request.Files.Count > 0)
                {
    
                    HttpFileCollection files = content.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        GSFileInfo fileInfo = new GSFileInfo();
                        using (MemoryStream streamCopy = new MemoryStream())
                        {
                            byte[] fileDataArr = null;
                            content.Request.Files[i].InputStream.CopyTo(streamCopy);
                            string parentPath = content.Request.Form["parentPathHidden"];
                          
                            fileDataArr = streamCopy.ToArray();
                            var test = content.Request.Files[i];
           
                            string ServerPath = content.Server.MapPath("~/uploads/" + file.FileName);
                            bool read = streamCopy.CanRead;
                            bool write = streamCopy.CanWrite;
    
                            fileInfo.Name = file.FileName;
                            fileInfo.Path = file.FileName;
                            fileInfo.ParentPath = "root"; //  Need to Read Parent Path From the Request 
                           
                            if (file.ContentType.Contains("image"))
                            {
    
                                fileInfo.Type = FileType.File;
                            }
                            else
                            {
                                fileInfo.Type = FileType.Folder;
                            }
    
    
    
                            fileInfo.Size = files[i].ContentLength;
    
                            fileInfo.MD5 = GetMD5(fileDataArr);
                            if (FilesBAL.InsertFile(fileInfo) == DALMessage.Success)
                            {
                                file.SaveAs(ServerPath);
                               content.Response.Write( Home.GetDataByParent("root"));
                            }
    
                        }
                    }
                }
            }
