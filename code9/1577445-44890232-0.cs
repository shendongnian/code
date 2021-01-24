You can get the LimitedWebPartManager for the page with the GetLimitedWebPartManager function on SharePoint Online as well, [MSDN][1]. You can then load the WebParts using the LimitedWebPartManager as below:
    var page = ctx.Web.GetFileByServerRelativeUrl(pageUrl);
    LimitedWebPartManager wpMgr = page.GetLimitedWebPartManager(Microsoft.SharePoint.Client.WebParts.PersonalizationScope.Shared);
    ctx.Load(wpMgr.WebParts);
    ctx.ExecuteQuery();
This will load all the webparts on the page. You can then get the WebPartDefinition of the webpart you require using it's index:
    WebPartDefinition webPartDef = wpMgr.WebParts[webpartIndex];
    ctx.Load(webPartDef);
    ctx.ExecuteQuery();
    
