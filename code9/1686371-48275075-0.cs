    var onlineCredentials = new SharePointOnlineCredentials(_SharePointSiteUser, securePassword);
    clientContext.RequestTimeout = 10000000;
    clientContext.Credentials = onlineCredentials; 
    Microsoft.SharePoint.Client.File file = clientContext.Web.GetFileByServerRelativeUrl(_SharePointSiteURL + "/Shared Documents/ABC/Test.pdf");
    FileVersionCollection fileVersions = file.Versions; 
    clientContext.Load(file); 
    clientContext.Load(fileVersions);
    clientContext.ExecuteQuery();
    
    // Download all versions of specific file as individual docs
    int index = 0;
    foreach (var version in fileVersions)
    {
    	if (version.VersionLabel == "2.0")
    	{
    	   var str = version.OpenBinaryStream();
    	   clientContext.ExecuteQuery();
    	   
    	   string filename = string.Format("d:\\downloaded\\doc-{0}.docx", index);
    	   using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
    	   {
    		 str.Value.CopyTo(fs);
    	   }
    	   index++;
    	}
    }
