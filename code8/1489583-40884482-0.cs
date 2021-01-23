            string fileName = "example.txt";
            string[] drives =Environment.GetLogicalDrives();
            List<string[]> findedFiles = new List<string[]>();
            foreach (string dr in drives)
            {
                    System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
                    if (!di.IsReady)
                    {
                        Console.WriteLine("The drive {0} could not be read", di.Name);
                        continue;
                    }
                    DirectoryInfo rootDir = di.RootDirectory;
                    Console.WriteLine($"Search in {rootDir}");
                    var findedFiletmp = Directory.GetFiles(rootDir.Name, fileName, SearchOption.TopDirectoryOnly);
                    if(findedFiletmp.Length>0)
                        findedFiles.Add(findedFiletmp);
                    var subDirectories = rootDir.GetDirectories();
                    
                    foreach (var subDirectory in subDirectories)
                    {
                        try
                        {
                            var findedFiletmp1 = Directory.GetFiles(subDirectory.Name, fileName, SearchOption.AllDirectories);
                            if (findedFiletmp1.Length > 0)
                                findedFiles.Add(findedFiletmp1);
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc.Message);
                        }
                    }
                
                Console.WriteLine($"Searching in {dr} finished");
            }
            foreach (var files in findedFiles)
            {
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
