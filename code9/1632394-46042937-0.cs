    using System;
    using System.IO;
    using System.Threading;
    namespace FileWatcherThreadApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileSystemWatcher fileWatcher = new FileSystemWatcher(@"C:\Users\BertSinnema\watch");
                //Enable events
                fileWatcher.EnableRaisingEvents = true;
                //Add event watcher
                fileWatcher.Changed += FileWatcher_Changed;
                fileWatcher.Created += FileWatcher_Changed;
                fileWatcher.Deleted += FileWatcher_Changed;
                fileWatcher.Renamed += FileWatcher_Changed;
                var maxThreads = 4;
                // Times to as most machines have double the logic processers as cores
                ThreadPool.SetMaxThreads(maxThreads, maxThreads * 2);
                Console.WriteLine("Listening");
                Console.ReadLine();
            }
            //This event adds the work to the Thread queue
            private static void FileWatcher_Changed(object sender, FileSystemEventArgs e)
            {
                ThreadPool.QueueUserWorkItem((o) => ProcessFile(e));
            }
            //This method processes your file, you can do your sync here
            private static void ProcessFile(FileSystemEventArgs e)
            {
                // Based on the eventtype you do your operation
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Changed:
                        Console.WriteLine($"File is changed: {e.Name}");
                        break;
                    case WatcherChangeTypes.Created:
                        Console.WriteLine($"File is created: {e.Name}");
                        break;
                    case WatcherChangeTypes.Deleted:
                        Console.WriteLine($"File is deleted: {e.Name}");
                        break;
                    case WatcherChangeTypes.Renamed:
                        Console.WriteLine($"File is renamed: {e.Name}");
                        break;
                }
            }
        }
    }
