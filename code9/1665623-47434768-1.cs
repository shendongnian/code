    var list = web.Lists.GetByTitle(sLibrary);
    clientContext.Load(list);
    clientContext.ExecuteQuery();
    
    ListItemCreationInformation listItemCreationInformation = null;
    if (!string.IsNullOrEmpty(sFolderName))
    {
    	listItemCreationInformation = new ListItemCreationInformation();
    	listItemCreationInformation.FolderUrl = string.Format("{0}Lists/{1}/{2}", sURL, sLibrary, sFolderName);
    }
    
    var listItem = list.AddItem(listItemCreationInformation);
    newItem["Title"] = sTitel;
    newItem["Description"] = sDescription;
    listItem.Update();
    clientContext.ExecuteQuery();                
    
    using (FileStream fs = new FileStream(sFilePath, FileMode.Open))
    {
    	var attInfo = new AttachmentCreationInformation();
    	attInfo.FileName = fs.Name;
    	attInfo.ContentStream = fs;                    
    
    	var att = listItem.AttachmentFiles.Add(attInfo);
    	clientContext.Load(att);
    	clientContext.ExecuteQuery();
    }
