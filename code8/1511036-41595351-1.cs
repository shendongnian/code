    public bool Process(int count = 0)
    {
        if (File.Exists("C:\\Users\\sk185462\\Desktop\\SVNUPDATED\\RevisionNumber.txt") && count < 3)
        {
            System.Diagnostics.Process.Start("C:\\Users\\sk185462\\Desktop\\SVNUPDATED\\SvnUninstallation.exe");
            Thread.Sleep(2000); // or long enough to ensure the uninstall process finishes executing
            //File exists
            Console.WriteLine("File exists");
            if(Process(++count))
               return true;
        }
        if (!File.Exists("C:\\Users\\sk185462\\Desktop\\SVNUPDATED\\RevisionNumber.txt"))
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
