    static void Main(string[] args)
    {
        string sourceDirectory = @"C:\dir1";
        string archiveDirectory = @"C:\dir2";
        try
        {
            var txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", SearchOption.AllDirectories);
            foreach (string currentFile in txtFiles)
            {
                string fileName = currentFile.Split("\\".ToCharArray()).Last();
                Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
