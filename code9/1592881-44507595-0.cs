    using System.IO;
    using System.IO.Compression;
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFolder = @"c:\temp";
            string zipFilePath = Path.Combine(sourceFolder, "test.zip");
            // TODO: Check if the archive exists maybe?
            using (ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
            {
                foreach (var directoryName in Directory.GetDirectories(sourceFolder))
                {
                    foreach (var filePath in Directory.GetFiles(directoryName))
                    {
                        var entry = archive.CreateEntry(filePath);
                    }
                }
            }
        }
    }
