    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Globalization;
    using System.Threading;
    namespace ConcoxClient
    {
        class Program
        {
            const int PORT = 8841;
            static void Main(string[] args)
            {
                string IP = "x.x.x.x";
                string loginMessage = "7878110103587390503134452020000100196A930D0A";
                string locationDataMessage = "78781F120B081D112E10CF027AC7EB0C46584900148F01CC00287D001FB8000380810D0A";
                string alarmmMessage = "787825160B0B0F0E241DCF027AC8870C4657E60014020901CC00287D001F726506040101003656A40D0A";
                string[] messages = { loginMessage, locationDataMessage, alarmmMessage };
                IPHostEntry ipHostInfo = Dns.GetHostEntry(IP);  //Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress local = IPAddress.Parse(IP);
                TcpClient client = new TcpClient();
                client.Connect(IP, PORT);
                while (true)
                {
                    foreach (string message in messages)
                    {
                        byte[] messageBytes = new byte[message.Length / 2];
                        for (int i = 0; i < message.Length; i += 2)
                        {
                            messageBytes[i / 2] = byte.Parse(message.Substring(i, 2), NumberStyles.HexNumber);
                        }
                        client.Client.Send(messageBytes);
                        //System.Threading.Thread.Sleep(1000);
                    }
                    Console.WriteLine("Hit return to send another message");
                    Console.ReadLine();
                }
            }
        }
    }
