        public void Stop()
        {
            this.Status = ServerStatus.Stopping;
            this.listener.Stop();
            this.cancellationTokenSource.Cancel();
            this.Status = ServerStatus.Stopped;
        }
        private async void ListenForConnections(CancellationToken cancellationToken)
        {
            try
            {
                while (this.Status == ServerStatus.Running)
                {
                    var socketTask = this.listener.AcceptSocketAsync();
                    var tcs = new TaskCompletionSource<bool>();
                    using (cancellationToken.Register(s => ((TaskCompletionSource<bool>)s).TrySetResult(true), tcs))
                    {
                        if (socketTask != await Task.WhenAny(socketTask, tcs.Task).ConfigureAwait(false))
                            break;
                    }
                    var context = new TcpContext(socketTask.Result);
                    this.OnConnectionReceived(context);
                }
            }
            catch (ObjectDisposedException)
            {
                // Closed
            }
        }
