	using System;
	using System.IO;
	using System.Net;
	using Contato_Vistoria.Droid; //My droid project
	[assembly: Xamarin.Forms.Dependency(typeof(FTP))] //You need to put this on iOS/droid class or uwp/etc if you wrote
	namespace Contato_Vistoria.Droid
	{
	    class FTP : IFtpWebRequest
	    {
	        public FTP() //I saw on Xamarin documentation that it's important to NOT pass any parameter on that constructor
	        {
	        }
	
	        /// Upload File to Specified FTP Url with username and password and Upload Directory if need to upload in sub folders
	        ///Base FtpUrl of FTP Server
	        ///Local Filename to Upload
	        ///Username of FTP Server
	        ///Password of FTP Server
	        ///[Optional]Specify sub Folder if any
	        /// Status String from Server
	        public string upload(string FtpUrl, string fileName, string userName, string password, string UploadDirectory = "")
	        {
	            try
	            {
	
	                string PureFileName = new FileInfo(fileName).Name;
	                String uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, PureFileName);
	                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
	                req.Proxy = null;
	                req.Method = WebRequestMethods.Ftp.UploadFile;
	                req.Credentials = new NetworkCredential(userName, password);
	                req.UseBinary = true;
	                req.UsePassive = true;
	                byte[] data = File.ReadAllBytes(fileName);
	                req.ContentLength = data.Length;
	                Stream stream = req.GetRequestStream();
	                stream.Write(data, 0, data.Length);
	                stream.Close();
	                FtpWebResponse res = (FtpWebResponse)req.GetResponse();
	                return res.StatusDescription;
	
	            }
	            catch(Exception err)
	            {
	                return err.ToString();
	            }
	        }
	    }
	}
