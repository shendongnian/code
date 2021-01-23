    public static void Process(int count = 0)
        {
            bool exists = File.Exists("C:\\Users\\sk185462\\Desktop\\SVNUPDATED\\RevisionNumber.txt");
            if (exists && count < 3)
            {
                System.Diagnostics.Process.Start("C:\\Users\\sk185462\\Desktop\\SVNUPDATED\\SvnUninstallation.exe");
                Thread.Sleep(2000); // or long enough to ensure the uninstall process finishes executing
                //File exists
                Console.WriteLine("File exists");
                Process(++count);
            }
            else
            {
                Console.WriteLine("Exceeded retry of 3 times. File did not uninstall.");
            }
            if (!exists)
                Console.WriteLine("File uninstalled");
        }
