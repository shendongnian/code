    var pageUrl = "/sites/practice3/SitePages/Home.aspx";
    // mark object you would like to access
    var list = ctx.Web.Lists.GetByTitle("News and Announcements");
    // prepare load query with SchemaXml property
    ctx.Load(list, l=>l.SchemaXml);
    ctx.ExecuteQuery(); // request the data
    
    AddWebPart(ctx, pageUrl, list.SchemaXml);
