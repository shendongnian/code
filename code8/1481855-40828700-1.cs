    // this all runs on a background, non-UI threed
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        ClearTempFiles(); //Clear all files before populating
    
        string[] files = (string[])e.Argument; // this is passed in from RunWorkerAsync
    
        List<string> toParse = new List<string>();
        foreach (string file in files)
        {
            FileAttributes attr = File.GetAttributes(file);
            if (attr.HasFlag(FileAttributes.Directory)) //If a folder has been included, add all files from within
            {
                toParse.AddRange(DirSearch(file));
            }
            else
            {
                toParse.Add(file); //Add files
            }
        }
               
        e.Result = new JobData(toParse); //Create new JobData from these files <---- Takes up to a few minutes with hundreds of files.
    }
