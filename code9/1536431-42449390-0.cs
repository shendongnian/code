            fileSystemWatcher1.EnableRaisingEvents = false;
            try
            {
                while (IsFileReady(e.FullPath) != true)
                {
                    Console.WriteLine("Waiting for file to be released by process");
                    continue;
                }
