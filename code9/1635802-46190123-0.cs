    // Code to retrieve Dropbox Local Folder
    var infoPath = @"Dropbox\info.json";
            var jsonPath = Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), infoPath);
    
            if (!System.IO.File.Exists(jsonPath)) jsonPath = Path.Combine(Environment.GetEnvironmentVariable("AppData"), infoPath);
    
            if (!System.IO.File.Exists(jsonPath)) {
                return "-2";
            } 
    
            var dropboxPath = System.IO.File.ReadAllText(jsonPath).Split('\"')[5].Replace(@"\\", @"\");
    
            string fileName = "Your FileName";
            string sourcePath = Server.MapPath("Source Path Here");
            string targetPath = dropboxPath;
    
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, "filename.extention");
            string destFile = System.IO.Path.Combine(targetPath, fileName);
    
            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
    
            // To copy a file to another location and 
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);
    
            if (System.IO.File.Exists(destFile))
            {
                System.IO.File.SetLastWriteTime(destFile, DateTime.Now);
            }
