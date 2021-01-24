	void IResultCallback.OnResult(Java.Lang.Object result)
	{
		var contentResults = (result).JavaCast<IDriveApiDriveContentsResult>();
		if (!contentResults.Status.IsSuccess) // handle the error
			return;
		Task.Run(() =>
		{
			var writer = new OutputStreamWriter(contentResults.DriveContents.OutputStream);
			writer.Write("Stack Overflow");
			writer.Close();
			MetadataChangeSet changeSet = new MetadataChangeSet.Builder()
				.SetTitle("New Text File")
				.SetMimeType("text/plain")
				.Build();
			DriveClass.DriveApi
				.GetRootFolder(_googleApiClient)
				.CreateFile(_googleApiClient, changeSet, contentResults.DriveContents);
		});
	}
