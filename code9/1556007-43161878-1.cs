        public void Start()
        {
            //Create Task with parameter
            Task search = new Task(() => new Action<int>(SomeSearchMethod)(4));
            // Create Normal Task
            Task download = new Task(SomeDownloadMethod);
            // Create Task with Return value            
            Task<string> proccessString = Task.FromResult(SomeProcessing());
            MessageBox.Show(proccessString.Result);
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
        private void SomeSearchMethod(int value)
        {
            MessageBox.Show("Parameter Search" + value.ToString());
        }
        private string SomeProcessing()
        {
            return "Proccess";
        }
