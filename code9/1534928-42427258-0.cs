    using System;
    using System.IO;
    using System.Diagnostics;
    
    // ...
        static void Main(string[] args)
        {
            byte[] resourceFile = Properties.Resources.Newspaper_PC_13_12_2013;
            string destination = Path.Combine(Path.GetTempPath(), "Newspaper_PC_13_12_2013.pdf");
            File.WriteAllBytes(destination, resourceFile);
            Process.Start(destination);
            AutoDelete(2000, destination);
            Console.Write("Press any key to quit . . . ");
            Console.ReadKey(true);
        }
        static async void AutoDelete(int milliseconds, string destination)
        {
            while (File.Exists(destination))
            {
                await Task.Delay(milliseconds);
                try
                {
                    File.Delete(destination);
                }
                catch
                {
                    continue;
                }
            }
        }
