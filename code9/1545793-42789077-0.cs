    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                RelativePaths p = new RelativePaths(@"u:\test");
                foreach (var str in p.MyFiles)
                {
                    Console.WriteLine(str);
                }
                Console.ReadKey();
            }
        }
    
        class MyFileInfo
        {
            public MyFileInfo(string path, string filename)
            {
                Path = path;
                Filename = filename;
            }
    
            public string Path { get; private set; }
            public string Filename { get; private set; }
    
            public override string ToString()
            {
                return $"{Path}, {Filename}";
            }
        }
    
        class RelativePaths
        {
            List<MyFileInfo> myPaths = new List<MyFileInfo>();
    
            public RelativePaths(string startingPath = @"U:\test")
            {
                DirectoryInfo dir = new DirectoryInfo(startingPath);
                PathSeparator(dir.FullName, dir);
            }
    
            public MyFileInfo[] MyFiles => myPaths.ToArray();
    
            public void PathSeparator(string originalPath, DirectoryInfo dir)
            {
                // Files in dir
                foreach (var file in dir.GetFiles())
                {
                    myPaths.Add(new MyFileInfo(file.DirectoryName.Substring(originalPath.Length),
                                               file.Name));
    
                }
    
                foreach (var folder in dir.GetDirectories())
                {
                    PathSeparator(originalPath, folder);
                }
            }
        }
    }
