	using System;
	using System.Net;
	using System.IO;
	//Only thing that changes to droid class is that \/
	using Foundation;
	using UIKit;
	using Contato_Vistoria.iOS;
	[assembly: Xamarin.Forms.Dependency(typeof(FTP))]
	namespace Contato_Vistoria.iOS 	//   /\
	{
	    class FTP : IFtpWebRequest
	    {
	        public FTP()
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
	            catch (Exception err)
	            {
	                return err.ToString();
	            }
	        }
	    }
	}
