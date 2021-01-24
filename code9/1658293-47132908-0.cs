    /// <summary>
    /// is adding an item to an existing Archive
    /// </summary>
    /// <param name="pathZipFile"></param>
    /// <param name="pathItem"></param>
    public static void AddItem(string pathZipFile, string pathItem)
    {
        string appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7zip", "7za.exe");
        if (SystemInformation.Is64BitOperatingSystem())
        {
            appPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "7zip", "x64", "7za.exe");
        }
        //
        // Setup the process with the ProcessStartInfo class.
        //
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = appPath;
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.Arguments = $"a -r {pathZipFile} {pathItem}";
        
        //
        // Start the process.
        //
        using (Process process = Process.Start(start))
        {
            //
            // Read in all the text from the process with the StreamReader.
            //
            if(process == null)
                throw new Exception("Failed to start the 7zip Process!");
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.Write(result);
            }
            process.WaitForExit();
            if (process.ExitCode != 0)
                throw new Exception($"Fehlercode von 7zip: {process.ExitCode}");
        }
    }
