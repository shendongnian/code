    public IList<Google.Apis.Drive.v3.Data.File> GetAllFiles()
	{
		// Define parameters of request.
		FilesResource.ListRequest listRequest = service.Files.List();
		listRequest.PageSize = 10;
		listRequest.Q = "mimeType='application/vnd.google-apps.spreadsheet'";
		
		// List files.
		return  listRequest.Execute().Files;
	}
