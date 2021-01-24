        private void Update1()
        {
            Task.Factory.StartNew(() =>
                {
                    var random = new Random();
                    var counter = random.Next(1, 20);
                    for (int i = counter; i > 0; i--)
                    {
                        Dispatcher.Invoke(() => UpdateCounter = i);
                        Task.Delay(1000).Wait();
                    }
                    Dispatcher.Invoke(// some function to update data...);
                }
            );
        }
        private async Task Update2()
        {
            var random = new Random();
            var counter = random.Next(1, 20);
            for (int i = counter; i > 0; i--)
            {
                UpdateCounter = i;
                await Task.Delay(1000);
            }
            // some function to update data...
        }
