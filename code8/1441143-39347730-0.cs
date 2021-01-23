    public class UploadInitialFile
        {
            public UploadInitialFile(){
                   
            }
    
            public UploadInitialFile(string fileName, int contentLength, string fileExtension)
            {
                Name = fileName;
                Size = contentLength;
                Extension = fileExtension;
            }
    
            public string Name      { get; set; }
            public int Size         { get; set; }
            public string Extension { get; set; }
        }
