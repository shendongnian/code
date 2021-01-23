        static void Main(string[] args)
        {
            Console.WriteLine("Enter file name...");
            string fileName = Console.ReadLine();
            var result = FindFile(fileName);
            foreach (var files in result)
            {
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
        }
        public static List<string[]> FindFile(string fileName)
        {
            string[] drives = Environment.GetLogicalDrives();
            List<string[]> findedFiles = new List<string[]>();
            foreach (string dr in drives)
            {
                Console.WriteLine($"Start looking in {dr}");
                System.IO.DriveInfo di = new System.IO.DriveInfo(dr);
                if (!di.IsReady)
                {
                    Console.WriteLine("The drive {0} could not be read", di.Name);
                    continue;
                }
                DirectoryInfo rootDir = di.RootDirectory;
                var findedFiletmp = Directory.GetFiles(rootDir.Name, fileName, SearchOption.TopDirectoryOnly);
                if (findedFiletmp.Length > 0)
                {
                    findedFiles.Add(findedFiletmp);
                    Console.WriteLine("Finded file.Continue search?(Y/N)");
                    string answer = Console.ReadLine();
                    if (answer.ToLower().Equals("n"))
                    {
                        break;
                    }
                }
                var subDirectories = Directory.GetDirectories(rootDir.Name);
                bool breaked = false;
                foreach (var subDirectory in subDirectories)
                {
                    try
                    {
                        var findedFiletmp1 = Directory.GetFiles(subDirectory, fileName, SearchOption.AllDirectories);
                        if (findedFiletmp1.Length > 0)
                        {
                            findedFiles.Add(findedFiletmp1);
                            Console.WriteLine("Finded file.Continue search?(Y/N)");
                            string answer = Console.ReadLine();
                            if (answer.ToLower().Equals("n"))
                            {
                                breaked = true;
                                break;
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
                }
                Console.WriteLine($"Finished looking in {dr}");
                if (breaked)
                    break;
            }
            return findedFiles;
        }
