    protected void Button1_Click(object sender, EventArgs e)  
          {
        
        string sourceDirectory = @"D:\project training\source";
        
                string targetDirectory = @"D:\project training\destiny";
        
                Copy(sourceDirectory, targetDirectory);
            }
            public static void Copy(string sourceDirectory, string targetDirectory)
            {
                DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
                DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
        
                CopyAll(diSource, diTarget);
            }
            public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
            {
        
        
        
                Directory.CreateDirectory(target.FullName);
                foreach (FileInfo fi in source.GetFiles())
                {
                    if (fi.Extension.Equals(".pdf"))
                    {
                        fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                    }
                }
        
        
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
