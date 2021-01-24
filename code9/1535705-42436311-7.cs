    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = args[0],
                archive = args[1],
                archiveDirectory = Path.GetDirectoryName(Path.GetFullPath(archive)),
                unpackDirectoryName = Guid.NewGuid().ToString();
            File.Delete(archive);
            ZipFileWithProgress.CreateFromDirectory(sourceDirectory, archive,
                new BasicProgress<double>(p => Console.WriteLine($"{p:P2} archiving complete")));
            ZipFileWithProgress.ExtractToDirectory(archive, unpackDirectoryName,
                new BasicProgress<double>(p => Console.WriteLine($"{p:P0} extracting complete")));
        }
    }
