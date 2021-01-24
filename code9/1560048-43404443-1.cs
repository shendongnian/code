    using (var ctx = new ClientContext(siteUrl))
    {
         ctx.Credentials = new SharePointOnlineCredentials(username, securePwd);
         var list = new ListCreationInformation()
         {
             Title = title
             Description = "User Created Document Library",
             TemplateType = asDocumentLibrary ? 101 : 100 // 100 is a custom list.
         };
        ctx.Web.Lists.Add(list);
        ctx.ExecuteQuery();
        success = true;
    }
