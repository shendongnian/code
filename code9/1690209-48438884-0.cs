    string targetSiteURL = @"https://xxx.sharepoint.com/sites/sitename";
    
    var login = "xxx@xxx.onmicrosoft.com";
    var password = "xxx";
    
    var securePassword = new SecureString();
    
    foreach (char c in password)
    {
    	securePassword.AppendChar(c);
    }
    SharePointOnlineCredentials onlineCredentials = new SharePointOnlineCredentials(login, securePassword);
    
    ClientContext ctx = new ClientContext(targetSiteURL);
    ctx.Credentials = onlineCredentials;
    
    List list = ctx.Web.Lists.GetByTitle("Documents");
    CamlQuery camlQuery = new CamlQuery();
    camlQuery.ViewXml = @"<View Scope='RecursiveAll'><Query></Query></View>";
    camlQuery.FolderServerRelativeUrl = folder.ServerRelativeUrl;
    ListItemCollection listItems = list.GetItems(camlQuery);
    clientContext.Load(listItems);
    clientContext.ExecuteQuery();
    
    foreach (var item in listItems)
    {
    	 if (item.FileSystemObjectType == FileSystemObjectType.File)
    	 {
    		 // This is a File
    	 }
    	 else if (item.FileSystemObjectType == FileSystemObjectType.Folder)
    	 {
    		 // This is a  Folder
    	 }
    }
