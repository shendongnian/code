    class Test
        {
            public Test()
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                backgroundWorker.RunWorkerAsync();
            }
            private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
            }
        }
