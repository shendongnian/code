    using System.Net;
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage request, TraceWriter log)
    {
        //Check if the request contains multipart/form-data.
        if (!request.Content.IsMimeMultipartContent())
        {
            return request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
        }
        
        //The root path where the content of MIME multipart body parts are written to
        string root = Path.Combine(System.Environment.GetEnvironmentVariable("HOME"), @"site\wwwroot\HttpTriggerCSharp1\");
        var provider = new MultipartFormDataStreamProvider(root);
        // Read the form data
        await request.Content.ReadAsMultipartAsync(provider);
        List<UploadedFileInfo> files = new List<UploadedFileInfo>();
        // This illustrates how to get the file names.
        foreach (MultipartFileData file in provider.FileData)
        {   
            var fileInfo = new FileInfo(file.Headers.ContentDisposition.FileName.Trim('"'));
            files.Add(new UploadedFileInfo()
            {
                FileName = fileInfo.Name,
                ContentType = file.Headers.ContentType.MediaType,
                FileExtension = fileInfo.Extension,
                FileURL = file.LocalFileName
            });
        }
        return request.CreateResponse(HttpStatusCode.OK, files, "application/json");
    }
    public class UploadedFileInfo
    {
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public string FileURL { get; set; }
        public string ContentType { get; set; }
    }
