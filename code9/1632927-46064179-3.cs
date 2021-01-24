    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    public class TCPTest
    {
        //Sample class to transfer between server and client
        public class User
        {
            public string Name { get; set; }
            public int  Id { get; set; }
            public DateTime BirthDate { set; get; }
        }
        public static void StartAll()
        {
            Task.Run(() => StartServer());
            Task.Run(() => StartClient());
        }
        static void StartServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();
            Console.WriteLine("Server Started");
            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("A new client is connected");
                ThreadPool.QueueUserWorkItem(ServerTask, client);
            }
        }
        static void ServerTask(object o)
        {
            using (var tcpClient = (TcpClient)o)
            {
                var stream = tcpClient.GetStream();
                var writer = new StreamWriter(stream);
                for (int i = 0; i < 10; i++)
                {
                    var user = new User() { Name = $"Joe{i}", Id = i , BirthDate = DateTime.Now.AddDays(-10000)}; 
                    var json = JsonConvert.SerializeObject(user);
                    writer.WriteLine(json); 
                    writer.Flush();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Server session ended..");
            }
        }
        static void StartClient()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 12345);
            var stream = client.GetStream();
            var reader = new StreamReader(stream);
            string json = "";
            while ((json = reader.ReadLine()) != null)
            {
                var user = JsonConvert.DeserializeObject<User>(json);
                Console.WriteLine($"Client received: Name={user.Name} Id={user.Id} BirthDate={user.BirthDate}");
            }
            Console.WriteLine("Client detected end of the session");
        }
    }
