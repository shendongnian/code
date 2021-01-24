	var folderName = "StackOverflow";
	using (var driveId = DriveClass.DriveApi.GetRootFolder(_googleApiClient))
	using (var query = new QueryClass.Builder().AddFilter(Filters.And(Filters.Eq(SearchableField.Title, folderName), Filters.Eq(SearchableField.Trashed, false))).Build())
	using (var metaBufferResult = await driveId.QueryChildrenAsync(_googleApiClient, query))
	{
		if (metaBufferResult.Status.IsSuccess)
		{
			DriveId folderId = null;
			foreach (var metaData in metaBufferResult.MetadataBuffer)
			{
				if (metaData.IsFolder && metaData.Title == folderName)
				{
					folderId = metaData.DriveId;
					break;
				}
			}
			IDriveFolder driveFolder = null;
			switch (folderId)
			{
				case null: // if folder not found, create it and fall through to default
					using (var folderChangeSet = new MetadataChangeSet.Builder().SetTitle(folderName).Build())
					using (var folderResult = await driveId.CreateFolderAsync(_googleApiClient, folderChangeSet))
					{
						if (!folderResult.Status.IsSuccess)
						{
							Log.Error(TAG, folderResult.Status.StatusMessage);
							break;
						}
						driveFolder = folderResult.DriveFolder;
					}
					goto default;
				default:
					driveFolder = driveFolder ?? folderId.AsDriveFolder();
					// create your file in the IDriveFolder obtained, 
					using (var contentResults = await DriveClass.DriveApi.NewDriveContentsAsync(_googleApiClient))
					{
						if (contentResults.Status.IsSuccess)
						{
							using (var writer = new OutputStreamWriter(contentResults.DriveContents.OutputStream))
							{
								writer.Write("StackOverflow Rocks");
								using (var changeSet = new MetadataChangeSet.Builder()
									.SetTitle("StackOverflow Rocks")
									.SetStarred(true)
									.SetMimeType("text/plain")
									.Build())
								using (var driveFileResult = await driveFolder.CreateFileAsync(_googleApiClient, changeSet, contentResults.DriveContents))
								{
									if (driveFileResult.Status.IsSuccess)
										Log.Debug(TAG, "File created, open https://drive.google.com to review it");
									else
										Log.Error(TAG, driveFileResult.Status.StatusMessage);
								}
							}
						}
					}
					driveFolder.Dispose();
					break;
			}
			folderId?.Dispose();
		}
		else
		{
			Log.Error(TAG, metaBufferResult.Status.StatusMessage);
		}
	}
