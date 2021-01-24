    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    class ClientServer {
        static void Main() {
            new Thread(() => { StartServer(5013); }).Start();
            Thread.Sleep(100);
            Console.WriteLine("\nPress enter to start the client...");
            Console.ReadLine();
            StartClient("127.0.0.1", "5013");
        }
        public static void StartServer(int port) {
            try {
                IPHostEntry hostInfo = Dns.GetHostEntry("localhost");
                string hostName = hostInfo.HostName;
                IPAddress ipAddress = hostInfo.AddressList[0];
                var server = new TcpListener(ipAddress, port);
                server.Start();
                Console.WriteLine($"Waiting for a connection at {server.LocalEndpoint}");
                Console.WriteLine("Press ctrl+c to exit server...");
                while (true) {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Server says - Client connected: {client.Client.RemoteEndPoint}");
                    ThreadPool.QueueUserWorkItem((state) => {
                        using (var _client = (TcpClient)state)
                        using (NetworkStream stream = _client.GetStream()) {
                            string msg = stream.ReadAsciiData();
                            if (msg == "Hello!") {
                                stream.WriteAsciiData($"Time:{DateTime.Now: yyyy/MM/dd HH:mm zzz}. Server name is {hostName}");
                            }
                        }
                    }, client);
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }
        public static void StartClient(string host, string port) {
            Console.WriteLine("Client started...");
            try {
                using (var client = new TcpClient(host, int.Parse(port)))
                using (NetworkStream stream = client.GetStream()) {
                    Console.WriteLine("Client says - Hello!");
                    stream.Write(Encoding.ASCII.GetBytes("Hello!"));
                    string msg = stream.ReadAsciiData();
                    Console.WriteLine($"Client says - Message from server: Server@{client.Client.RemoteEndPoint}: {msg}");
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
            Console.WriteLine("Client exited");
        }
    }
    static class Utils {
        public static void WriteAsciiData(this NetworkStream stream, string data) {
            stream.Write(Encoding.ASCII.GetBytes(data));
        }
        public static string ReadAsciiData(this NetworkStream stream) {
            var buffer = new byte[1024];
            int read = stream.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer, 0, read);
        }
        public static void Write(this NetworkStream stream, byte[] data) {
            stream.Write(data, 0, data.Length);
        }
    }
