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
                string IP = "192.168.1.27";
                string loginMessage1 =        "7878110103587390503134452020000100196A930D0A";
                string locationDataMessage1 = "78781F120B081D112E10CF027AC7EB0C46584900148F01CC00287D001FB8000380810D0A";
                string alarmmMessage1 = "787825160B0B0F0E241DCF027AC8870C4657E60014020901CC00287D001F726506040101003656A40D0A";
                string heartMessage1 = "78780A134401040001000508450D0A";
                string heartPowerCutAlarmMessage1 = "78780A131001040001000515FC0D0A";
                string connectOilMessage1 = "78781915110001A963484659443D53756363657373210002001EF8930D0A";
                string[] messages1 = { loginMessage1, locationDataMessage1, alarmmMessage1, heartMessage1, heartPowerCutAlarmMessage1, connectOilMessage1 };
                string loginMessage2 =        "787811010358739050313446202000010091CABD0D0A";
                string locationDataMessage2 = "78781F12110612112E10CF027AC7EB0C46584900148F01CC00287D001FB800039AA10D0A";
                string alarmmMessage2 = "787825161106180E241DCF027AC8870C4657E60014020901CC00287D001F726506040101003606FD0D0A";
                string[] messages2 = { loginMessage2, locationDataMessage2, alarmmMessage2 };
                IPHostEntry ipHostInfo = Dns.GetHostEntry(IP);  //Dns.Resolve(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress local = IPAddress.Parse(IP);
                TcpClient client1 = new TcpClient();
                client1.Connect(IP, PORT);
                //TcpClient client2 = new TcpClient();
                //client2.Connect(IP, PORT + 1);
                while (true)
                {
                    foreach (string message in messages1)
                    {
                        byte[] messageBytes = new byte[message.Length / 2];
                        for (int i = 0; i < message.Length; i += 2)
                        {
                            messageBytes[i / 2] = byte.Parse(message.Substring(i, 2), NumberStyles.HexNumber);
                        }
                        client1.Client.Send(messageBytes);
                        //System.Threading.Thread.Sleep(1000);
                    }
                    foreach (string message in messages2)
                    {
                        byte[] messageBytes = new byte[message.Length / 2];
                        for (int i = 0; i < message.Length; i += 2)
                        {
                            messageBytes[i / 2] = byte.Parse(message.Substring(i, 2), NumberStyles.HexNumber);
                        }
                        //client2.Client.Send(messageBytes);
                        //System.Threading.Thread.Sleep(1000);
                    }
                    Console.WriteLine("Hit return to send another message");
                    Console.ReadLine();
                }
            }
        }
    }
