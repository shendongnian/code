    namespace SupersocketTest
    {
        using System;
        using SuperSocket.SocketBase;
        class Program
        {
            static void Main(string[] args)
            {
                var server = new AppServer();
                bool success = server.Setup(8080);
                Console.WriteLine($"Server setup: {success}");
                Console.ReadKey();
            }
        }
    }
