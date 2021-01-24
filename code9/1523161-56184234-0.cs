        public static void LaunchThreads(string path_file)
        {
            int i = 0;
            using(var sw = File.CreateText(path_file))
            using(var syncWriter = TextWriter.Synchronized(sw)) 
            {
                Dictionary<int, Thread> threadsdico = new Dictionary<int, Thread>();
                while (i < MAX_THREAD)
                {
                    Thread thread = new Thread(() => ThreadEntryWriter(syncWriter));
                    thread.Name = string.Format("ThreadsWriters{0}", i);
                    threadsdico.Add(i, thread);
                    thread.Start();
                    i++;
                }
                int zz = 0;
                while (zz < threadsdico.Count())
                {
                    threadsdico[zz].Join();
                    zz++;
                }
            }
        }
        
        public static void ThreadEntryWriter(TextWriter writer)
        {
            int w = 0;
            while (w < 99)
            {       
                writer.WriteLine($"{w} - test");
                w++;
            }
        }
