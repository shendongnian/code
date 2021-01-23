    FileInfo filesInfo;
    foreach (string s in files)
    {
        string fileName = Path.GetFileName(s);
        filesInfo = new FileInfo(fileName);
    }
    try
    {
        if (filesInfo.LastWriteTime.Date == DateTime.Today.Date)
        {
            File.Move(src, dst);
            Console.WriteLine("Modified files in {0} were moved to {1}", src, dst);
        }
        else
        {
            Console.WriteLine("No new or modified files were created today.");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("The process failed: {0}", e.ToString());
    }
