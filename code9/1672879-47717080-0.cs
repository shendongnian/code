    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    namespace ConsoleApplication16
    {
        class Program
        {
            const string IP = "123.456.789.000";
            const int PORT_NUMBER = 1234;
            static AutoResetEvent autoEvent = new AutoResetEvent(false);
            static void Main(string[] args)
            {
                GPSClient client = new GPSClient(IP, PORT_NUMBER);
                //start http client or equivalent here
                while (true)
                {
                    autoEvent.Reset();
                    autoEvent.WaitOne();
      
                    //wait for message from user/client on service port
                    
                    string message = client.message;
                    //send message back to user/client
                    
                }
            }
        }
        public class WebServer
        {
        }
        public class GPSClient
        {
            const int BUFFER_SIZE = 256;
            TcpClient client = null;
            NetworkStream stream = null;
            Byte[] bytes = new Byte[BUFFER_SIZE];
            public string message { get; set; }
     
            public GPSClient(string ip, int port)
            {
                try
                {
                    Console.WriteLine("Connecting to Device... ");
                    client.Connect(ip, port);
                    Console.WriteLine("Connected!");
                    stream = client.GetStream();
                    stream.BeginRead(bytes, 0, BUFFER_SIZE, new AsyncCallback(HandleDeivce), stream);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
            }
            public void HandleDeivce(IAsyncResult ar)
            {
                NetworkStream stream = ar.AsyncState as NetworkStream;
                
                string data = null;
                int i = stream.Read(bytes, 0, BUFFER_SIZE);
                
                data = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data);
                message = data;
                if (data.StartsWith("##"))
                {
                   data = "LOAD";
                }
                else
                {
                   data = "ON";
                }
                byte[] msg = Encoding.ASCII.GetBytes(data);
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Sent: {0}", data);
                stream.BeginRead(bytes, 0, BUFFER_SIZE, new AsyncCallback(HandleDeivce), stream);
            }
        }
    }
