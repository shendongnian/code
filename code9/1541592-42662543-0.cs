	namespace Contato_Vistoria
	{
    		public interface IFtpWebRequest
    		{
        		string upload(string FtpUrl, string fileName, string userName, string password, string UploadDirectory = "");
    		}
	}
