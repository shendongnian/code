    using System.IO;
    
    namespace ConsoleApp1
    {
        class Program
        {
            private const string BackupDirectory = "C:\\A00000001\\";
            private const string LookupDirectory = "C:\\A00000002\\";
            static void Main(string[] args)
            {
                SynchronizeSourceAndDestination("C:\\A00000001\\");
            }
    
            public static void SynchronizeSourceAndDestination(string dir)
            {
                foreach (string file in Directory.GetFiles(dir))
                {
                    string destFilePath = file.Replace(BackupDirectory, LookupDirectory);
    
                    if (!File.Exists(destFilePath))
                    {
                        // Delete file from Backup
                        File.Delete(file);
                    }
                }
    
                foreach (string directory in Directory.GetDirectories(dir))
                {
                    string destinationDirectory = directory.Replace(BackupDirectory, LookupDirectory);
    
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.Delete(directory, true);
                        continue;
                    }
                    SynchronizeSourceAndDestination(directory);
                }
            }
        }
    }
