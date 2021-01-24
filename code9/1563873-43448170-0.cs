        void WalkDirectoryTree(System.IO.DirectoryInfo root)
            {
                System.IO.FileInfo[] files = null;
                System.IO.DirectoryInfo[] subDirs = null;
                  
                try
                {
                    files = root.GetFiles("*.*");
                }               
                catch (UnauthorizedAccessException e)
                {                   
                }    
                catch (System.IO.DirectoryNotFoundException e)
                {
                    
                }
                
                if (files != null)
                {
                    foreach (System.IO.FileInfo file in files)
                    {                        
                       if(file.Extension == ".ext"){
                            //open the file here, and make your modification
                        }
                    }
                       
                    subDirs = root.GetDirectories();
    
                    foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                    {
                        // Recursive call for each sub directory.
                        WalkDirectoryTree(dirInfo);
                    }
                }            
            }
