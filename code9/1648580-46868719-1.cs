    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    
    namespace SimpleTcpClient
    {
        class SimpleTcpClient : IDisposable
        {
            readonly TcpClient _client;
    
            public SimpleTcpClient(string host, int port)
            {
                _client = new TcpClient(host, port);
            }
            public void Send(byte[] payload)
            {
                // Get network order of array length
                ulong length = (ulong)IPAddress.HostToNetworkOrder(payload.LongLength);
                var stream = _client.GetStream();
                // Write length
                stream.Write(BitConverter.GetBytes(length), 0, sizeof(long));
                // Write payload
                stream.Write(payload, 0, payload.Length);
                stream.Flush();
                Console.WriteLine("Have sent {0} bytes", sizeof(long) + payload.Length);
            }
            public void Dispose()
            {
                try { _client.Close(); }
                catch { }
            }
        }
        class Program
        {
            class DTO
            {
                public string Name { get; set; }
                public int Age { get; set; }
                public double Weight { get; set; }
                public double Height { get; set; }
                public string RawBase64 { get; set; }
            }
    
            static void Main(string[] args)
            {
                // Set server name/ip-address
                string server = "192.168.1.101";
                // Set server port
                int port = 8080;
                string[] someNames = new string[]
                {
                    "James", "David",    "Christopher",  "George",   "Ronald",
                    "John", "Richard",  "Daniel",   "Kennet",  "Anthony",
                    "Robert","Charles", "Paul", "Steven",   "Kevin",
                    "Michae", "Joseph", "Mark", "Edward",   "Jason",
                    "Willia", "Thomas", "Donald",   "Brian",    "Jeff"
                };
                // Init random generator
                Random rnd = new Random(Environment.TickCount);
                int i = 1;
                while (true) {
                    try {
                        using (var c = new SimpleTcpClient(server, port)) {
                            byte[] rawData = new byte[rnd.Next(16, 129)];
                            rnd.NextBytes(rawData);
    
                            // Create random data transfer object
                            var d = new DTO() {
                                Name = someNames[rnd.Next(0, someNames.Length)],
                                Age = rnd.Next(10, 101),
                                Weight = rnd.Next(70, 101),
                                Height = rnd.Next(165, 200),
                                RawBase64 = Convert.ToBase64String(rawData)
                            };
    
                            // UTF-8 doesn't have endianness - so we can convert it to byte array and send it
                            // More about it - https://stackoverflow.com/questions/3833693/isn-t-on-big-endian-machines-utf-8s-byte-order-different-than-on-little-endian 
                            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(d));
                            c.Send(bytes);
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine("Get exception when send: {0}\n", ex);
                    }
                    Thread.Sleep(200);
                    i++;
                }
            }
        }
    }
