    string wwwroot = "c:\\Inetpub\\wwwroot";
    string virtualDirectoryName = "myNewApp";
    string sitepath = "IIS://localhost/W3SVC/1/ROOT";
    
    DirectoryEntry vRoot = new DirectoryEntry(sitepath);
    DirectoryWntry vDir = vRoot.Children.Add(virtualDirectoryName, 
                                "IIsWebVirtualDir");
    vDir.CommitChanges();
    
    vDir.Properties["Path"].Value = wwwroot + "\\" + virtualDirectoryName;
    vDir.Properties["DefaultDoc"].Value = "Default.aspx";
    vDir.Properties["DirBrowseFlags"].Value = 2147483648;
    vDir.Commitchanges();
    vRoot.CommitChanges();
