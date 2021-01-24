    string _SharePointSiteURL = @"https://lz.sharepoint.com/sites/lz";
    
    var _SharePointSiteUser = "lz@lz.onmicrosoft.com";
    var password = "Password";
    
    var securePassword = new SecureString();
    
    foreach (char c in password)
    {
    	securePassword.AppendChar(c);
    }
    
    using (var clientContext = new ClientContext(_SharePointSiteURL))
    {
    	var onlineCredentials = new SharePointOnlineCredentials(_SharePointSiteUser, securePassword);
    	clientContext.RequestTimeout = 10000000;
    	clientContext.Credentials = onlineCredentials;
    	Web web = clientContext.Web;
    	clientContext.Load(web, website => website.ServerRelativeUrl, website => website.Url);
    	clientContext.ExecuteQuery();
    
    	var spFile = clientContext.Web.GetFileByServerRelativeUrl((web.ServerRelativeUrl.EndsWith("/") ? web.ServerRelativeUrl : web.ServerRelativeUrl + "/") + "Shared Documents/ABC/Test.pdf");
    	clientContext.Load(spFile);
    	FileVersionCollection versions = spFile.Versions;
    	clientContext.Load(versions);
    	var oldVersions = clientContext.LoadQuery(versions.Where(v => v != null));
    	clientContext.ExecuteQuery();
    	if (oldVersions != null)
    	{
    		foreach (Microsoft.SharePoint.Client.FileVersion _version in oldVersions)
    		{
    			if (_version.VersionLabel == "2.0")
    			{
    				var localPath = @"c:\test\";
    				if (!Directory.Exists(localPath))
    				{
    					Directory.CreateDirectory(localPath);
    				}
    
    				using (var wc = new System.Net.WebClient())
    				{                       
    					wc.Credentials = onlineCredentials;
    					wc.Headers.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
    					wc.Headers["User-Agent"] = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; MDDC)";
    					wc.DownloadFile(web.Url + "/" + _version.Url, localPath+"Test.pdf");
    				}                  
    			}
    		}
    	}
    }
