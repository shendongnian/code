    List<Google.Apis.Drive.v3.Data.File> allFiles = new List<Google.Apis.Drive.v3.Data.File>();
    Google.Apis.Drive.v3.Data.FileList result = null;
    while (true)
    {
        if (result != null && string.IsNullOrWhiteSpace(result.NextPageToken))
            break;
        FilesResource.ListRequest listRequest = service.Files.List();
        listRequest.PageSize = 1000;
        listRequest.Fields = "nextPageToken, files(id, name)";
        if (result != null)
            listRequest.PageToken = result.NextPageToken;
        result = listRequest.Execute();
        allFiles.AddRange(result.Files);
    }
