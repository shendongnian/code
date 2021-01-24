    //...
    // Previous code
    //...
     var docs = _context.Web.Lists.GetByTitle(Library);
     var listItem = docs.GetItemById(listItemId);
     _context.Load(docs);
     clientContext.Load(listItem, i => i.File);
     clientContext.ExecuteQuery();
     var fileRef = listItem.File.ServerRelativeUrl;
     var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
     var fileName = Path.Combine(filePath,(string)listItem.File.Name);
     using (var fileStream = System.IO.File.Create(fileName))
     {                  
          fileInfo.Stream.CopyTo(fileStream);
     }
