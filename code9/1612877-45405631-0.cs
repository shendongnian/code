    using System;
    using System.IO;
    using System.Linq;
    using SevenZipExtractor;
    namespace _7zip
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string workingDirectory = @"C:\Profile\Repositories\7zipPlayground\7zip\bin\Debug\";
                using (var archiveFile = new ArchiveFile(Path.Combine(workingDirectory, "test.dmg"), @"C:\Program Files\7-Zip\7z.dll"))
                {
                    var files = archiveFile.Entries?.ToList();
                    foreach (var f in files)
                    {
                        Console.WriteLine($"File: {f.FileName}");
                    }
                    var hfsFile = files.FirstOrDefault(x => x.FileName.ToLower().Contains("hfs"));
                    if (hfsFile == null)
                        return;
                    hfsFile.Extract(Path.Combine(workingDirectory, hfsFile.FileName));
                    using (var hfsArchiveFile = new ArchiveFile(Path.Combine(workingDirectory, hfsFile.FileName), @"C:\Program Files\7-Zip\7z.dll"))
                    {
                        files = hfsArchiveFile.Entries?.ToList();
                        foreach (var f in files)
                        {
                            Console.WriteLine($"File: {f.FileName}");
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
