    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Sockets;
    using System.IO;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    TcpClient client = new TcpClient("localhost",4523);
                    NetworkStream ns = client.GetStream();
                    byte[] buffer = new byte[100];
                    string str = Console.ReadLine();
                    BinaryWriter bw = new BinaryWriter(client.GetStream());
                    bw.Write(str);
    
                    BinaryReader br = new BinaryReader(client.GetStream());
                    Console.WriteLine(br.ReadString());
                }
            }
        }
    }
