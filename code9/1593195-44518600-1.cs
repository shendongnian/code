    ListItem newItem = List.AddItem(creationInfo);
    newItem["Title"] = "Test";
    // ...
    
    newItem.Update();
    clientContext.Load(newItem, i => i.Id);
    clientContext.ExecuteQuery();
    
    var item = List.GetItemById(newItem.Id);
    
    using (MemoryStream ms = new MemoryStream(contents))
    {
    	// ...
    	var att = item.AttachmentFiles.Add(attInfo);
    	item.Update();
    	clientContext.ExecuteQuery();
    }
