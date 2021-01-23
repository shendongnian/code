    FilesResource.ListRequest listRequest = _service.Files.List();
	listRequest.PageSize = 100;
	listRequest.Fields = "nextPageToken, files(id, name)";
	// List files.
	var result =  listRequest.Execute();
	IList<Google.Apis.Drive.v3.Data.File> files =result.Files;
	Console.WriteLine("Files:");
	while (files!=null && files.Count > 0)
	{
	    foreach (var file in files)
	    {
	        Console.WriteLine("{0} ({1})", file.Name, file.Id);
	    }
	    if (!string.IsNullOrWhiteSpace(result.NextPageToken))
	    {
	        listRequest = _service.Files.List();
	        listRequest.PageToken = result.NextPageToken;
	        listRequest.PageSize = 100;
	        listRequest.Fields = "nextPageToken, files(id, name)";
	        result = listRequest.Execute();
	        files = result.Files;
	    }
	}
