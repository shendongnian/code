    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Sockets;
    using System.Threading;
    using System.IO;
    
    namespace Sever
    {
        class Program
        {
            static void Main(string[] args)
            {
                TcpListener serverSocket = new TcpListener(4523);
                serverSocket.Start();
                Console.WriteLine("Started!");
                while (true)
                {
                    TcpClient clientSocket = serverSocket.AcceptTcpClient();
                    handleClient clientx = new handleClient();
                    clientx.startClient(clientSocket);
                }
            }
        }
    
        public class handleClient
        {
            TcpClient clientSocket;
            public void startClient(TcpClient inClientSocket)
            {
                this.clientSocket = inClientSocket;
                Thread ctThread = new Thread(Chat);
                ctThread.Start();
            }
    
            private void Chat()
            {
                byte[] buffer = new byte[100];
                while (true)
                {
                    NetworkStream ns = clientSocket.GetStream();
                    BinaryReader reader = new BinaryReader(clientSocket.GetStream());
                    Console.WriteLine(reader.ReadString());
    
                    BinaryWriter bw = new BinaryWriter(clientSocket.GetStream());
                    string str = Console.ReadLine();
                    bw.Write(str);
                }
            }
         }
    }
