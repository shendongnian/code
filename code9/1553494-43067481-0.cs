    using System;
    using System.IO.Compression;
    
    namespace ZipReader
    {
        class Program
        {
            const string zipPath = @"D:\test\test.zip";
    
            static void Main(string[] args)
            {
                using (var archive = ZipFile.OpenRead(zipPath))
                {
                    foreach (var entry in archive.Entries)
                    {
                        Console.WriteLine(entry.FullName);
                    }
                }
    
                Console.ReadKey();
            }
        }
    }
