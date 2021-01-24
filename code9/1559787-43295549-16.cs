     [DataContract]
     public class UploadFileRequest
     {
           public string FileName { get; set; }
           public string Path { get; set; }
           public byte[] FileContents { get; set; }
     }
