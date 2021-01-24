    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    
    namespace ConsoleAppDemo
    {
        class Program
        {
            private static object lockIbj = new object();
            private static List<string> _proccessedFiles = new List<string>();
            private static readonly List<string> toProccessFiles = new List<string>();
            private static List<string> _proccessingFiles = new List<string>();
            private const string directory = @"C:\Path";
            private const string extension = @"*.txt";
            static void Main(string[] args)
            {
                FileSystemWatcher f = new FileSystemWatcher();
                f.Path = directory;
                f.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                f.Filter = extension ;
                f.Created += F_Created;
                f.EnableRaisingEvents = true;
    
                Timer manualWatcher = new Timer(ManuallWatcherCallback, null, 0, 3000);
    
                Timer manualTaskRunner = new Timer(ManuallRunnerCallback, null, 0, 10000);
    
                Console.ReadLine();
            }
    
            private static void F_Created(object sender, FileSystemEventArgs e)
            {
                lock (lockIbj)
                {
                    toProccessFiles.Add(e.FullPath);
                    Console.WriteLine("Adding new File from watcher: " + e.FullPath);
                }
    
            }
    
            private static void ManuallWatcherCallback(Object o)
            {
                var files = Directory.GetFiles(directory, extension);
                lock (lockIbj)
                {
                    foreach (var file in files)
                    {
                        if (!_proccessedFiles.Contains(file) && !toProccessFiles.Contains(file) && !_proccessingFiles.Contains(file))
                        {
                            toProccessFiles.Add(file);
                            Console.WriteLine("Adding new File from manuall timer: " + file);
                        }
                    }
    
                }
            }
    
            private static bool processing;
            private static void ManuallRunnerCallback(Object o)
            {
                if (processing)
                    return;
    
                while (true)
                {
                    //you could proccess file in parallel
                    string fileToProcces = null;
    
                    lock (lockIbj)
                    {
                        fileToProcces = toProccessFiles.FirstOrDefault();
                        if (fileToProcces != null)
                        {
                            processing = true;
                            toProccessFiles.Remove(fileToProcces);
                            _proccessingFiles.Add(fileToProcces);
                        }
                        else
                        {
                            processing = false;
                            break;
    
    
                        }
                    }
    
                    if (fileToProcces == null)
                        return;
    
                    //Must add error handling
                    ProccessFile(fileToProcces);
                }
            }
    
            private static void ProccessFile(string fileToProcces)
            {
                Console.WriteLine("Processing:" + fileToProcces);
                lock (lockIbj)
                {
                    _proccessingFiles.Remove(fileToProcces);
                    _proccessedFiles.Add(fileToProcces);
                }
            }
        }
    }
