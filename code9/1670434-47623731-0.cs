    var folderId = "0BwwA4oUTeiV1TGRPeTVjaWRDY1E";
    var fileMetadata = new File()
    {
        Name = "photo.jpg",
        Parents = new List<string>
        {
            folderId
        }
    };
    FilesResource.CreateMediaUpload request;
    using (var stream = new System.IO.FileStream("files/photo.jpg",
        System.IO.FileMode.Open))
    {
        request = driveService.Files.Create(
            fileMetadata, stream, "image/jpeg");
        request.Fields = "id";
        request.Upload();
    }
    var file = request.ResponseBody;
    Console.WriteLine("File ID: " + file.Id);
