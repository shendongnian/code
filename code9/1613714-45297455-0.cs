    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Threading.Tasks;
    
    static class P
    {
        static void Main()
        {
    
            File.WriteAllLines("dummy.txt",
                Enumerable.Range(1, 200).Select(i => "this is some contents: line " + i));
    
            WriteSize("dummy.txt");
    
            var t = Task.Run(() => DoTheThing(Environment.CurrentDirectory + "\\", "dummy.txt"));
            Console.WriteLine("Waiting for completion (don't do this in real code, ever)...");
            t.Wait();
            Console.WriteLine("Complete");
            WriteSize("dummy.txt.gz");
        }
    
        private static void WriteSize(string path)
        {
            var file = new FileInfo(path);
            Console.WriteLine(path + ":" + file.Length + " bytes");
        }
    
        async static Task DoTheThing(string path, string fileName)
        {
            using (var outputStream = new FileStream(path + fileName + ".gz", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var zipStream = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    using (var inputStream = new FileStream(path + fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        await inputStream.CopyToAsync(zipStream);
                    }
                }
            }
        }
    }
