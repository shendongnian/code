    class Class1
    {
        public delegate void ProcessProgressEventHandler(int progress);
        public ProcessProgressEventHandler ProcessProgress;
        public EventHandler ProcessEnd;
        public void StartHeavyProcess()
        {
            System.Threading.Thread vThread = new System.Threading.Thread(HeavyProcess);
            ProcessProgress += OnProgress;
            ProcessEnd += OnProcessEnd;
            vThread.Start();
        }
        private void OnProcessEnd(object sender, EventArgs e)
        {
            Console.WriteLine("Process end!");
        }
        private void OnProgress(int progress)
        {
            Console.WriteLine("Progress: " + progress.ToString());
        }
        public void HeavyProcess()
        {
            int done = 0;
            while (done < 100)
            {
                if (ProcessProgress != null)
                    ProcessProgress(done);
                done++;
            }
            if (ProcessEnd != null)
                ProcessEnd(this, new EventArgs());
        }
    }
