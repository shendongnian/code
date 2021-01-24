    if (folder.IndexOf('\\') == 0)
    {
        string dir = "\\\\" + serveurName + "\\Test-Projects\\" + pPrjName.Text + folder;
        Directory.CreateDirectory(dir);                    
        DirectoryInfo di = new DirectoryInfo(dir);
        DirectorySecurity ds = di.GetAccessControl();                    
        ds.SetOwner(serviceAccount);
        FileSystemAccessRule permissions = new FileSystemAccessRule(serviceAccount, FileSystemRights.FullControl, AccessControlType.Allow);
        ds.AddAccessRule(permissions);
        di.SetAccessControl(ds);
    }
