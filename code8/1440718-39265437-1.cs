    using (SPSite site = new SPSite(SPContext.Current.Site.ID)){
    using (SPWeb web = site.OpenWeb(SPContext.Current.Web.ID))
    {
       string userName = web.CurrentUser.LoginName;
    }}
