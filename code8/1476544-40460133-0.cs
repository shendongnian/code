    private static object _sync = new object();
    .....
    
    if (Process.GetProcessesByName("my_process").Length > 0)
    {
        lock(_sync)//mutex here, so, only one thread will be able to launch this code.
        {
            if (Process.GetProcessesByName("my_process").Length > 0)
            {
                writelog("Started uploading files");
                upload_file();
                writelog("Finished uploading files");
            }
        }
    }
