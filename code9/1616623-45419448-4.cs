    [ServiceContract]
    public interface IFileService
    {
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "/ProcessFile")]
        string ProcessFile(Stream file);
    }
    
    public class FileService : IFileService
    {
        public string ProcessFile(Stream file)
        {
            const int bufferLength = 32;
            const int maxSize = 256;
            var buffer = new byte[bufferLength];
            int bytesRead, totalBytesRead = 0;
    
            do
            {
                bytesRead = file.Read(buffer, 0, bufferLength);
                totalBytesRead += bytesRead;
    
                if (totalBytesRead > maxSize)
                    return $"File is too large - maximum {maxSize} bytes allowed.";
            }
            while (bytesRead > 0);
    
            return $"Total {totalBytesRead} bytes read.";
        }
    }
