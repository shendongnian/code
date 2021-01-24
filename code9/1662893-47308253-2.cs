    ctx.Load(list, l => l.DefaultDisplayFormUrl);
    ctx.Load(uploadFile.ListItemAllFields,item => item.Id);
    ctx.Load(ctx.Site, s => s.Url);
    ctx.ExecuteQuery();
    var itemUrl = String.Format("{0}{1}?ID={2}",ctx.Site.Url,list.DefaultDisplayFormUrl, uploadFile.ListItemAllFields.Id);
 
