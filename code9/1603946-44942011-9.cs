    class Program
    {
        private const int _kportNumber = 5678;
        static void Main(string[] args)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Loopback, _kportNumber);
            ConnectedEndPoint server = ConnectedEndPoint.Connect(remoteEndPoint, (c, s) => WriteLine(s));
            _StartUserInput(server);
            _SafeWaitOnServerRead(server).Wait();
        }
        private static void _StartUserInput(ConnectedEndPoint server)
        {
            // Get user input in a new thread, so main thread can handle waiting
            // on connection.
            new Thread(() =>
            {
                try
                {
                    string line;
                    while ((line = ReadLine()) != "")
                    {
                        server.WriteLine(line);
                    }
                    server.Shutdown();
                }
                catch (IOException e)
                {
                    WriteLine($"Server {server.RemoteEndPoint} IOException: {e.Message}");
                }
                catch (Exception e)
                {
                    WriteLine($"Unexpected server exception: {e}");
                    Environment.Exit(1);
                }
            })
            {
                // Setting IsBackground means this thread won't keep the
                // process alive. So, if the connection is closed by the server,
                // the main thread can exit and the process as a whole will still
                // be able to exit.
                IsBackground = true
            }.Start();
        }
        private static async Task _SafeWaitOnServerRead(ConnectedEndPoint server)
        {
            try
            {
                await server.ReadTask;
            }
            catch (IOException e)
            {
                WriteLine($"Server {server.RemoteEndPoint} IOException: {e.Message}");
            }
            catch (Exception e)
            {
                // Should never happen. It's a bug in this code if it does.
                WriteLine($"Unexpected server exception: {e}");
            }
        }
    }
