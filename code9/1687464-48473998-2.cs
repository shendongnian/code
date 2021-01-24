    public interface IFileService
        {
            Task SendCloud(IList<FileDto> modelList, string localPath);
        }	
    	
    	public class FileService : IFileService
        {
    		public Task SendCloud(IList<FileDto> modelList,string localPath)
            {
                /// `ftpUserName`, `ftpPassword` and `storagePath` is get from Web.Config.
                string ftpUserName = ConfigurationManager.AppSettings["ftpUserName"];
                string ftpPassword = ConfigurationManager.AppSettings["ftpPassword"];
                string storagePath = ConfigurationManager.AppSettings["fileServiceStoragePath"];
    
                /// Uploaded files are sent to the cloud server.
                foreach (var model in modelList)
                {
                    FtpWebRequest req = (FtpWebRequest)WebRequest.Create(storagePath + model.StorageName);
    
                    req.UseBinary = true;
                    req.Method = WebRequestMethods.Ftp.UploadFile;
                    req.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                    byte[] fileData = File.ReadAllBytes(localPath + "\\" + model.StorageName);
                    req.ContentLength = fileData.Length;
    
                    Stream reqStream = req.GetRequestStream();
                    reqStream.Write(fileData, 0, fileData.Length);
                    reqStream.Close();
                }
    
                return Task.CompletedTask;
            }
    		
    	}
