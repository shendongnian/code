    private async void BlahBahBlahAsync()
        {
            Thread testThread = new Thread(delegate () { });
            newThread = new Thread(delegate ()
            {
                Timeconsuming();
            });
            newThread.Start();
            while (testThread.IsAlive)
            {
                await Task.Delay(50);
            }
        }
        private void Timeconsuming()
        {
            // stuff that takes a while
        }
