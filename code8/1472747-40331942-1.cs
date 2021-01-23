        public void Readfiles(string inputDirectoryPath, string outputDirectoryPath, ConcurrentQueue<string> queue, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var dir = new DirectoryInfo(inputDirectoryPath);
                    FileInfo[] f = dir.GetFiles();
                    foreach (System.IO.FileInfo fi in f)
                    {
                        var filePath = Path.Combine(fi.DirectoryName, fi.Name);
                        //File.Copy(filePath, outputDirectoryPath + "\\" + fi.Name);
                        // Open the file to read from.
                        string textFromFile = File.ReadAllText(filePath);
                        queue.Enqueue(textFromFile);
                        Console.WriteLine(textFromFile);
                        Console.WriteLine("thread 1 call read files method ");
                        //Console.WriteLine("{0}: {1}: {2}", fi.Name, fi.LastAccessTime, fi.Length);
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }
                catch (Exception excep)
                {
                    Console.WriteLine("An error occurred: '{0}'", excep);
                    Throw excep;
                }
            }
           
        }
