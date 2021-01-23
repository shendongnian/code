        Google.Apis.Services.BaseClientService.Initializer bcs = new Google.Apis.Services.BaseClientService.Initializer();
        bcs.ApiKey = "38a0f7d505fe18fec64fbf343ecaaaf310dbd744";
        bcs.ApplicationName = "sampleApp";
        Google.Apis.Drive.v3.DriveService service = new Google.Apis.Drive.v3.DriveService(bcs);
        
        // Define parameters of request.
        Google.Apis.Drive.v3.FilesResource.ListRequest listRequest = service.Files.List();
        string folderID = "1234567"; //Change this for your folder ID.
        listRequest.Q = "'" + folderID + "' in parents";
        listRequest.PageSize = 10;
        listRequest.Fields = "nextPageToken, files(id, name)";
        // List files.
        IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
        Console.WriteLine("Files:");
        if (files != null && files.Count > 0)
        {
            foreach (var file in files)
            {
                Console.WriteLine("{0} ({1})", file.Name, file.Id);
            }
        }
        else
        {
            Console.WriteLine("No files found.");
        }
        Console.Read();
