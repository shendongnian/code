        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            List<Task> tasks = new List<Task>();
            tasks.Add(RunPipeServer(tokenSource.Token));
            for (var i = (uint)0; i < 30; i++)
            {
                var index = i;
                tasks.Add(RunPipeClient(index, tokenSource.Token));
            }
            Console.ReadLine();
            tokenSource.Cancel();
            Task.WaitAll(tasks.ToArray());
        }
        private const string PipeName = "{6FDABBF8-BFFD-4624-A67B-3211ED7EF0DC}";
        static async Task RunPipeServer(CancellationToken token)
        {
            try
            {
                var stw = new Stopwatch();
                int clientCount = 0;
                while (!token.IsCancellationRequested)
                {
                    stw.Restart();
                    var pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.InOut,
                         NamedPipeServerStream.MaxAllowedServerInstances,
                         PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                    try
                    {
                        token.Register(() => pipeServer.Close());
                        await Task.Factory.FromAsync(pipeServer.BeginWaitForConnection, pipeServer.EndWaitForConnection, null);
                        clientCount++;
                        Console.WriteLine($"server connection #{clientCount}. {stw.ElapsedMilliseconds} ms");
                        HandleClient(pipeServer);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("RunPipeServer exception: " + ex.Message);
                        pipeServer.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("RunPipeServer exception: " + ex.Message);
                Console.WriteLine(ex);
            }
        }
        // Left this method synchronous, as in your example it does almost nothing
        // in this example. You might want to make this "async Task..." as well, if
        // you wind up having this method do anything interesting.
        private static void HandleClient(NamedPipeServerStream pipeServer)
        {
            pipeServer.Close();
        }
        static async Task RunPipeClient(uint i, CancellationToken token)
        {
            try
            {
                var j = 0;
                while (!token.IsCancellationRequested)
                {
                    using (var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.InOut, PipeOptions.None))
                    {
                        pipeClient.Connect(5000);
                        try
                        {
                            Console.WriteLine($"connected client {i}, connection #{++j}");
                            await pipeClient.ReadAsync(new byte[1], 0, 1);
                        }
                        finally
                        {
                            pipeClient.Close();
                        }
                    }
                }
                Console.WriteLine($"client {i} exiting normally");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RunPipeClient({i}) exception: {ex.Message}");
            }
        }
