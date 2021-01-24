    using System;
    using System.Net;
    using System.Net.Sockets;
    class Program
    {
        static void Main(string[] args)
        {
            using (UdpClient client = new UdpClient(11221, AddressFamily.InterNetwork))
            {
                Console.WriteLine("Waiting for broadcast...");
                client.EnableBroadcast = true;
                client.ReceiveAsync().ContinueWith((t) => HandleBroadcast(t.Result)).Wait();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
        }
        static void HandleBroadcast(UdpReceiveResult result)
        {
            Console.WriteLine($"Received broadcast from {result.RemoteEndPoint}, attempting to connect via TCP");
            Socket socket = new Socket(result.RemoteEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(result.RemoteEndPoint.Address, 11220));
        }
    }
