    using System;
    using System.Net;
    using System.Net.Sockets;
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, 11220));
            listener.Start();
            listener.AcceptSocketAsync().ContinueWith((t) => HandleClient(t.Result));
            Console.WriteLine($"Listening for TCP connections at port 11220...");
            using (UdpClient broadcaster = new UdpClient(AddressFamily.InterNetwork))
            {
                broadcaster.EnableBroadcast = true;
                Console.WriteLine("Broadcasting...");
                broadcaster.Send(new byte[] { 1, 2, 3 }, 3, new IPEndPoint(IPAddress.Broadcast, 11221));
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Q)
            {
                Console.WriteLine("Press 'Q' to quit");
            }
        }
        static void HandleClient(Socket socket)
        {
            Console.WriteLine($"TCP connection accepted ({socket.RemoteEndPoint})!");
        }
    }
