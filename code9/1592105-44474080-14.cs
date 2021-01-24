    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Globalization;
    namespace ConsoleApplication61
    {
        class Program
        {
            const int PORT = 8841;
            static void Main(string[] args)
            {
                string IP = "X.X.X.X";
                string loginMessage = "7878110103587390503134452020000100196A930D0A";
                IPHostEntry ipHostInfo = Dns.GetHostEntry(IP);  //Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress local = IPAddress.Parse(IP);
                TcpClient client = new TcpClient();
                byte[] loginMessageBytes = new byte[loginMessage.Length / 2];
                for (int i = 0; i < loginMessage.Length; i += 2)
                {
                    loginMessageBytes[i / 2] = byte.Parse(loginMessage.Substring(i, 2), NumberStyles.HexNumber);
                }
                client.Connect(IP, PORT);
                while (true)
                {
                    client.Client.Send(loginMessageBytes);
                    Console.WriteLine("Hit return to send another message");
                    Console.ReadLine();
                }
            }
        }
    }
