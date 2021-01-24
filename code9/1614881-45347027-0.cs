    namespace WebService
    {
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class MyWCFService : IFileService
        {
            public Stream DownloadFile()
            {
                var filePath = "test.txt";
                if (string.IsNullOrEmpty(filePath))
                    throw new FileNotFoundException("File not found");
                return File.OpenRead(filePath);
        }
    }
    namespace WebService
    {
        [ServiceContract]
        public interface IFileService
        {
            [WebGet]
            Stream DownloadFile(string FileId);
        }
    }
