    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    
    namespace Client
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                TcpClient client = new TcpClient();
                var task = client.ConnectAsync("localhost", 65000);
                task.Wait();
                if(client.Connected)
                {
                    Console.WriteLine("Client connected");
                    var stream = client.GetStream();
                    var data = Encoding.ASCII.GetBytes("test");
                    stream.Write(data, 0, data.Length);
                }
                else
                {
                    Console.WriteLine("Client NOT connected");
                }
                Thread.Sleep(60000);
            }
        }
    }
