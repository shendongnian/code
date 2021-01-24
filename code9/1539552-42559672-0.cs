        static int count;
        public async Task Start()
        {
            var previousDateTime = DateTime.MinValue;
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;
            try
            {
                while (!CancellationToken.IsCancellationRequested)
                {
                    if (CheckForUpdate())
                    {
                        Update(previousDateTime);
                    }
                    await Task.Delay(PollingInterval * 1000, CancellationToken);
                    Debug.WriteLine("here " + count);
                }
                CancellationToken.ThrowIfCancellationRequested();
            }
            catch (OperationCanceledException oc)
            {
                Debug.WriteLine(oc.Message);
            }
        }
