      foreach (string dir in Directory.GetDirectories(dr.ToString()))
      {
        FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Read, dir);
        try
        {
            permission.Demand();
            var files = Directory.GetFiles(dir, "*.myox");
            if ( files != null && files.Length > 0 )
                lblAllFiles.Items.AddRange(files);
        }
        catch (Exception Error)
        {
    
        }
     }
