            var ports = 1234;
            try
            {
                Thread.Sleep(100);
                var serverSocket = new TcpListener(IPAddress.Any, ports);
                var clientSocket = default(TcpClient);
                int counter = 0;
                serverSocket.Start();
                counter += 1;
                var source = new CancellationTokenSource();
                Task.Factory.StartNew(() =>
                {
                    while(true)
                    {
                        clientSocket = serverSocket.AcceptTcpClient();
                        MessageBox.Show(ports + " " + "Connected!");
                    }
                }, source.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            }
            catch (Exception w)
            {
                MessageBox.Show(ports + " " + "Connection error!");
            }
