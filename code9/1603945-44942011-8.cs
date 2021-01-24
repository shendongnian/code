    class Program
    {
        private const int _kportNumber = 5678;
        static void Main(string[] args)
        {
            ChatServer server = new ChatServer(_kportNumber);
            server.Status += (s, e) => WriteLine(e.StatusText);
            Task serverTask = _WaitForServer(server);
            WriteLine("Press return to shutdown server...");
            ReadLine();
            server.Shutdown();
            serverTask.Wait();
        }
        private static async Task _WaitForServer(ChatServer server)
        {
            try
            {
                await server.ListenTask;
            }
            catch (Exception e)
            {
                WriteLine($"Server exception: {e}");
            }
        }
    }
