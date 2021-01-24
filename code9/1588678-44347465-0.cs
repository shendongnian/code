    foreach(string pfile in printdoc)
    {
        ProcessStartInfo info = new ProcessStartInfo();
        info.Verb = "print";
        info.CreateNoWindow = true;
        info.FileName = pfile;
        info.WindowStyle = ProcessWindowStyle.Hidden;
    
        //You can shorten your existing code to a single line using Process.Start(
        Process p = Process.Start(info);
        p.WaitForExit();
    }
