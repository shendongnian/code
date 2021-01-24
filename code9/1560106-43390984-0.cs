    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    
    namespace TestCSharpSocket
    {
      class Program
      {
        static void Main(string[] args)
        {
            try
            {
                // This work fine  ----------------------------
                IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.33"), 8642);
                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                string welcome = "Welcome";
                byte[] data = Encoding.ASCII.GetBytes(welcome);
                server.SendTo(data, data.Length, SocketFlags.None, RemoteEndPoint);
                Console.WriteLine("Welcome send");
                
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sender);
                data = new byte[256];
                int recv = server.ReceiveFrom(data, ref Remote);
                server.Close();
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            }
            catch (SocketException sex)
            {
                Console.WriteLine("Time Out: " + sex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
      }
    }
