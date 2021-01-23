    static void CreateVDir(string metabasePath, string vDirName, string physicalPath)
    {
      //  metabasePath is of the form "IIS://<servername>/<service>/<siteID>/Root[/<vdir>]"
      //    for example "IIS://localhost/W3SVC/1/Root" 
      //  vDirName is of the form "<name>", for example, "MyNewVDir"
      //  physicalPath is of the form "<drive>:\<path>", for example,"C:\Inetpub\Wwwroot"
     
      try
      {
        DirectoryEntry site = new DirectoryEntry(metabasePath);
       string className = site.SchemaClassName.ToString();
      if ((className.EndsWith("Server")) || (className.EndsWith("VirtualDir")))
      {
      DirectoryEntries vdirs = site.Children;
      DirectoryEntry newVDir = vdirs.Add(vDirName, (className.Replace("Service", "VirtualDir")));
      newVDir.Properties["Path"][0] = physicalPath;
      newVDir.Properties["AccessScript"][0] = true;
      // These properties are necessary for an application to be created.
      newVDir.Properties["AppFriendlyName"][0] = vDirName;
      newVDir.Properties["AppIsolated"][0] = "1";
      newVDir.Properties["AppRoot"][0] = "/LM" + metabasePath.Substring(metabasePath.IndexOf("/", ("IIS://".Length)));
      newVDir.CommitChanges();
     
    }
    else
      
      }
     catch (Exception ex)
     {
       
     }
    }
