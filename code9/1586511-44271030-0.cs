    ClientContext context = new ClientContext("https://SharePointListURL");
    var library = context.Web.Lists.GetByTitle("Documents");
    var list = context.Web.Lists.GetByTitle("Test");
    
    var file = library.GetItemById(1).File;
    var data = file.OpenBinaryStream();
    context.Load(file);
    context.ExecuteQuery();
    
    var item = list.GetItemById(1);
    context.Load(item);
    context.ExecuteQuery();
    
    var attachment = new AttachmentCreationInformation();
    attachment.FileName = file.Name;
    using (MemoryStream ms = new MemoryStream())
    {
    	data.Value.CopyTo(ms);
    	attachment.ContentStream = ms;
    	item.AttachmentFiles.Add(attachment);
    	context.ExecuteQuery();
    }
