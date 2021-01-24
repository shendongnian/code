    private static void initXML()
    {
        Timer timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += (y,z) => 
        {
            foreach(string file in Directory.GetFiles(@"C:\xxx\baseDir\inbox")
            {
                MoveFile(file);
            }
        };
        
        timer.Start();
    }
    private void MoveFile(string file)
    {
        string XMLPath = @"\\xxx\d$\CIP\Admin\Prod\SN\Import\Eingang\eSCHKG\";
        string fileName = Path.GetFileName(file);
        if (File.Exists(file))
            // Ensure that the target does not exist.
            if (File.Exists(Path.Combine(XMLPath,fileName )))
                File.Delete(Path.Combine(XMLPath, fileName ));
            WaitReady(file);
            try
            {
                File.Move(file, Path.Combine(XMLPath, fileName));
            }
            catch (IOException ex)
            {
                eventWriteEx(ex, "XML");
            }
        }
