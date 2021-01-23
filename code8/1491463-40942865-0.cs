        public static void SendFileWebDav(string FileToSend)
        {
            if (!DoesFileExist(FileToSend))
            {
                throw new Exception(string.Format("Cannot Find File {0}", FileToSend));
            }
            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.UserName = WebDavUploadSettings.Default.Username;
            sessionOptions.Password = WebDavUploadSettings.Default.Password;
            if (string.IsNullOrWhiteSpace(WebDavUploadSettings.Default.FolderPathToPushTo)) //WINSCP will throw an error if root directory doesn't start with /
            {
                //Haven't tested this.
                sessionOptions.WebdavRoot = "/";
            }
            else
            {
                sessionOptions.WebdavRoot = WebDavUploadSettings.Default.FolderPathToPushTo.ToString(); //Added .ToString() here because I was getting 404 error other wise? Maybe because is was not reading in the setting correctly.
            }
            //Make sure you define this as a URL without protocal. (Leave off Https:// and Http://)
            sessionOptions.HostName = WebDavUploadSettings.Default.Website;
            sessionOptions.Protocol = Protocol.Webdav;
            Session WebDavSession = new Session();
            try
            {
                WebDavSession.Open(sessionOptions);
                TransferOptions TransferOptions = new TransferOptions();
                TransferOptions.TransferMode = TransferMode.Automatic;
                TransferOperationResult transferResult;
                transferResult = WebDavSession.PutFiles(FileToSend,Path.GetFileName(FileToSend), false, TransferOptions);
                transferResult.Check();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                WebDavSession.Close();
            }
        }
