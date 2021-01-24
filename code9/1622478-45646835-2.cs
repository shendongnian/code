      bool restoreTheBackup()
        {
            try
            {
                //
                takeOffline(fullPath);
                // load .mdf
                loadMDFDatabaseFile();
                // load _log.ldf
                loadLDFDatabaseFile();
                //
                bringOnline(fullPath);
                return true;
            }
            catch
            {
                //
            }
            return false;
        }
   
    // txtPath.txt :
    // location to get database files from to replace with current files.
        void loadLDFDatabaseFile()
        {
            string fileName = "Database_log.ldf";
            string targetPath = executablePath;
            string sourcePath = txtPath.Text;
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
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
        }
        void loadMDFDatabaseFile()
        {
            string fileName = "Database.mdf";
            string targetPath = executablePath;
            string sourcePath = txtPath.Text;
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
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
        }
