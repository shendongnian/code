        public void Start()
        {
            //Create Task
            Task search = new Task(SomeSearchMethod);
            Task download = new Task(SomeDownloadMethod);
            // Start Task
            search.Start();
            download.Start();
            // Wait untill task finisht
            search.Wait();
            download.Wait();
            /* or for both tasks*/
            Task.WaitAll(); 
        }
        private void SomeDownloadMethod()
        {
            //logic
        }
        public void SomeSearchMethod()
        {
            //logic
        }
