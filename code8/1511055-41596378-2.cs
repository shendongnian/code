    private void Application_Startup(object sender, StartupEventArgs e)
    {
        string applicationPath = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in
        string saveFilePath = Path.Combine(applicationPath, "printini.txt"); // add a file name to this path.  This is your full file path.
    
        if (File.Exists(saveFilePath))
        {
            PRINTER_NAME = File.ReadAllText(saveFilePath);
        }
        else
        {
            // prompt the user for a printer...
        }
    }
