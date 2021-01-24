    // Upload
    FileCreationInformation fileInfo = new FileCreationInformation();
	fileInfo.Content = IOFile.ReadAllBytes(filePath);
	fileInfo.Url = Path.GetFileName(filePath);
    Microsoft.SharePoint.Client.File uploadFile = rootFolder.Files.Add(fileInfo);
    // Columns setting
    ListItem listItem = uploadFile.ListItemAllFields;
    listItem["Field1"] = "foo";
    listItem["Field2"] = "bar";
    listItem.Update();
    // Execution
    context.ExecuteQuery();
