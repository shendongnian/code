    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            const string shortcut = @"C:\test.lnk"; // Shortcut file name here
            string pathOnly = System.IO.Path.GetDirectoryName(shortcut);
            string filenameOnly = System.IO.Path.GetFileName(shortcut);
            Shell32.Shell shell = new Shell32.Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                Console.WriteLine(link.Path);
            }
            Console.ReadKey();
        }
    }
