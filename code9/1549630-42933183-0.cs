        private bool isRunning;
        public async void Start()
        {
            if (isRunning)
                return;
            isRunning = true;
            while (isRunning)
            {
                await DoWork();
                //wait period.
                await Task.Delay(TimeSpan.FromSeconds(10));
                if (!isRunning)
                    return;
            }
        }
        private async Task DoWork()
        {
            //Do your work here.
        }
        public void Stop()
        {
            isRunning = false;
        }
