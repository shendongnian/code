      bool getDatabaseCopy()
        {
            try
            {
                //
                takeOffline(fullPath);
                // copy database.mdf
                copyDBMDF();
                // copy database_log.ldf
                copyDB_logLDF();
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
        // folder location to save database files in
        void copyDBMDF()
        {
            string fileName = "Database.mdf";
            string sourceFile = fullPath;
            string targetPath = txtPath.Text;
            // Use Path class to manipulate file and directory paths.
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
        void copyDB_logLDF()
        {
            string fileName = "Database_log.ldf";
            string sourcePath = executablePath;
            string targetPath = txtPath.Text;
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
