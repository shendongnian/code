    public bool Process(int count = 0)
    {
        bool exists = File.Exists("C:\\Users\\sk185462\\Desktop\\SVNUPDATED\\RevisionNumber.txt");
        if (exists && count < 3)
        {
            System.Diagnostics.Process.Start("C:\\Users\\sk185462\\Desktop\\SVNUPDATED\\SvnUninstallation.exe");
            Thread.Sleep(2000); // or long enough to ensure the uninstall process finishes executing
            //File exists
            Console.WriteLine("File exists");
            if(Process(++count))
               return true;
        }
        if (!exists)
        {
            Console.WriteLine("File uninstalled");
            return true;
        }
        else
        {
            Console.WriteLine("Exceeded retry of 3 times. File did not uninstall.");
            return false;
        }
    }
