    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.IO;
    using System.Text;
    using Microsoft.Win32;
    
    namespace HelloWorld
    {
        class Program
        {
            public static void Main(string[] args)
            {
    
                Console.WriteLine("Connexion au serveur 62.210.130.212");
                using (client = new TcpClient("62.210.130.212", 35025))
                using (NetworkStream networkStream = client.GetStream())
                {
                    byte[] usernameBytes = Encoding.ASCII.GetBytes(username);
                    networkStream.Write(usernameBytes, 0, usernameBytes.Length);
        
                    while (true)
                    {
                        Byte[] data = new Byte[256];
                        Int32 bytes = networkStream.Read(data, 0, data.Length);
                        String responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                        Console.WriteLine("recieved: " + responseData);
                    }
                }
            }
        }
    }
