    public async void NotMultithreading(string name, string srcPath, string desPath)
    {
        //Your code sample used this line
        //DirectoryInfo directory = new DirectoryInfo(srcFile);
        //But I suspect you should use srcPath, which is probably your bug.
        DirectoryInfo directory = new DirectoryInfo(srcPath);
        FileInfo[] files = directory.GetFiles(name + ".pdf");
        foreach (FileInfo t in files)
        {
            try
            {
                var desFile = Path.Combine(desPath, t.Name);
                t.MoveTo(desFile);
                await PrintReport(desFile);
            }
            catch (Exception e)
            {
                MessageBox.Show("Moving and Printing error: " + e.Message);
            }
        }
    }
    
    private Task PrintReport(string filePrint)
    {
        ProcessStartInfo info = new ProcessStartInfo();
        info.Verb = "print";
        info.FileName = filePrint;
        info.CreateNoWindow = true;
        info.WindowStyle = ProcessWindowStyle.Hidden;
    
        return Task.Run(() =>
        {
            try
            {
                Process p = Process.Start(info);
                p.WaitForExit();
            }
            catch (Exception e)
            {
                MessageBox.Show("Encounted a problem while printing! " +
                                    e.Message);
    
            }
        });
    }
