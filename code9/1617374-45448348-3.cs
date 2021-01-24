    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Hazel;
    using Hazel.Tcp;
    namespace HazelExample
    {
    class ClientExample
    {
        static Connection connection;
        public static void Main(string[] args)
        {
            NetworkEndPoint endPoint = new NetworkEndPoint("127.0.0.1", 4296);
            connection = new TcpConnection(endPoint);
            connection.DataReceived += DataReceived;
            Console.WriteLine("Connecting!");
            connection.Connect();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            connection.Close();
        }
    }
    }
