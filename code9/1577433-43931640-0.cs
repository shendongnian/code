        public void SaveStockInfoToAnotherFile(string sPath, string dPath, string filename)
        {
            string sourcePath = sPath;
            string destinationPath = dPath;
            string sourceFile = System.IO.Path.Combine(sourcePath, filename);
            string destinationFile = System.IO.Path.Combine(destinationPath, filename);
            if (!System.IO.Directory.Exists(destinationPath))
            {
                System.IO.Directory.CreateDirectory(destinationPath);
            }
            System.IO.File.Copy(sourceFile, destinationFile, true);
        }
