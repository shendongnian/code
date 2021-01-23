    var list = ctx.Web.Lists.GetByTitle("Documents");
    var docSetContentType = ctx.Site.RootWeb.ContentTypes.GetById("0x0120D520");
    ctx.Load(docSetContentType);
                
    ctx.Load(list.RootFolder);
    ctx.ExecuteQuery();
    var result = DocumentSet.Create(ctx, list.RootFolder, docSetName, docSetContentType.Id);
    ctx.ExecuteQuery();
