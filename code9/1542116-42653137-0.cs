        private CancellationTokenSource cts;
        public async void MyButtonhandler(object sender, EventArgs e) {
            cts = new CancellationTokenSource();
            try {
                var result = await Task.Run(() => ReadAll(cts));
                if (result) {
                    //success
                } else {
                    //failure
                }
            } catch (TaskCanceledException ex) {
            }            
        }
        internal async Task<bool> ReadAll(CancellationTokenSource cts) {
            byte[] data = new byte[1];
            var timeout = TimeSpan.FromSeconds(10);
            var ReadAllTask = Task.Run(() => {
                // Read all information
                // [omit communication exchange via COM port]
                
            }, cts.Token);
            if (await Task.WhenAny(ReadAllTask, Task.Delay(timeout)) == ReadAllTask) {
                return true;
            }
            cts.Cancel();
            return false;
        }
