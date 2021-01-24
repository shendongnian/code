        public static void Main(string[] args)
        {
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 100; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    resetEvent.WaitOne();
                }));
            }
            Thread.Sleep(100);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, 5556));
            listener.Listen(1);
            SocketAsyncEventArgs args1 = new SocketAsyncEventArgs();
            args1.Completed += (sender, eventArgs) =>
            {
                Console.WriteLine($"Accepted {args1.SocketError}");
                resetEvent.Set();
            };
            listener.AcceptAsync(args1);
            SocketAsyncEventArgs args2 = new SocketAsyncEventArgs();
            args2.RemoteEndPoint = new IPEndPoint(IPAddress.Loopback, 5556);
            args2.Completed += (sender, eventArgs) => Console.WriteLine("Connected");
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.ConnectAsync(args2);
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("all tasks completed");
        }
 
