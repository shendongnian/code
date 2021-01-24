    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;
    
        Stopwatch sw = Stopwatch.StartNew();
        using (StreamReader sr = new StreamReader(@"path"))
        {
            String line;
            int lines = 0;
           
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("path"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    file.WriteLine(CreateMD5(line)+':'+line);
                    worker.ReportProgress(lines++);
                }
            }
        }
    }
