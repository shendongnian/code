     string parentSiteUrl = Helper.GetParentWebUrl(siteUrl);
                        clientContext = new ClientContext(parentSiteUrl);
                        clientContext.Credentials = CredentialCache.DefaultCredentials;
                        clientContext.Load(clientContext.Web, w => w.Url, w => w.Lists, w => w.ServerRelativeUrl, w => w.Title, w => w.SiteGroups);                        
                        clientContext.ExecuteQuery();
