    using (var ctx = GetContext(webUri.ToString(), userName, password))
    {
        var pagesList = ctx.Web.Lists.GetByTitle("Pages");
        var pageLayout = PublishingPage.GetPageLayout(ctx, "ArticleLeft.aspx");
        PublishingPage.Create(pagesList, pageLayout,"Welcome.aspx","<h1>Welcome</h1>");
    }
