    private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        //construct the list of folder to be copied
        List<DirectoryInfo> listOfFolders = new List<DirectoryInfo>();
        if (test1) 
           listOfFolders.Add(folder1);
        if (test2)
           listOfFolders.Add(folder2);
        if (test3)
           listOfFolders.Add(folder3);
        //begin to copy
        for (int i = 0; i < listOfFolders.Count; i++)
        {
            listOfFolders[i].Copy(...); //copy only one folder in the list
            int step = ((i + 1) / listOfFolders.Count) * 100; //calculate the progress
            backgroundWorker1.ReportProgress(step);
        }
    }
