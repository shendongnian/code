    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace ConsoleApplication2
    {
        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type Enter to exit:::");
            StartWatchers();
            Console.ReadLine();
        }
        public static void StartWatchers()
        {
            string[] ArrayPaths = new string[2];
            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
        ArrayPaths[0] = @"\\WifeyPC\c$\User\Wifey\Desktop";
        ArrayPaths[1] = @"\\HubbyPC\c$\Users\Hubby\Desktop";top";
            int i = 0;
            foreach (String String in ArrayPaths)
            {
                watchers.Add(MyWatcherFatory(ArrayPaths[i]));
                i++;
            }
            foreach (FileSystemWatcher watcher in watchers)
            {
                watcher.EnableRaisingEvents = true; ;
                Console.WriteLine("Watching this folder {0}", watcher.Path);
                i++;
            }
        }
        public static FileSystemWatcher MyWatcherFatory(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher(path);
            watcher.Changed += Watcher_Created;
            watcher.Path = path;
            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            return watcher;
        }
        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            FileInfo fileInfo = new FileInfo(e.FullPath);
            Console.WriteLine("File Created!! :: {0}", e.FullPath);
        }
    }
    }
