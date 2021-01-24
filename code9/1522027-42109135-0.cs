        public void Stop()
        {
            this.Status = ServerStatus.Stopping;
            this.listener.Stop();
            this.listeningThread.Abort();
            this.Status = ServerStatus.Stopped;
        }
        /// <summary>
        ///     Listens for connections.
        /// </summary>
        private async void ListenForConnections()
        {
            try
            {
                while (this.Status == ServerStatus.Running)
                {
                    var socket = await this.listener.AcceptSocketAsync();
                    var context = new TcpContext(socket);
                    this.OnConnectionReceived(context);
                }
            }
            catch (ObjectDisposedException)
            {
                // Closed
            }
        }
