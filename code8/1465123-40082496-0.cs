    try
            {
                FileInfo fileDatails = new FileInfo(AsyncImageUpload.PostedFile.FileName);/* here you can get file using you source like OFD or FileUpload Controls */
                string exten = fileDatails.Extension;
                Stream fs = this.AsyncImageUpload.FileContent;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length); /* convert file to byte */
                String Base64file = Convert.ToBase64String(bytes);
                destinationPath = Server.MapPath(TEMP_PATH + fileDatails.Name);
                Byte[] frombytes = Convert.FromBase64String(Base64file);
                File.WriteAllBytes(destinationPath, frombytes); /*write file to destination folder on server */
            }
            catch (Exception exp)
            {
                throw exp;
            }
  
