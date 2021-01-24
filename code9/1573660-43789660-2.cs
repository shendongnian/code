    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading;
    using System.IO;
    using System.Collections;
    using System.Net;
    
    class TcpServer
    {
        private TcpListener _server;
        private Boolean _isRunning;
    
        public TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();
    
            _isRunning = true;
    
            LoopClients();
        }
    
        public void LoopClients()
        {
            while (_isRunning)
            {
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();
    
                // client found.
                // create a thread to handle communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }
    
        private byte[] ReadBytes(Stream s, int length)
        {
            byte[] bytes = new byte[length];
            int read, total = 0;
            while (total < length)
            {
                read = s.Read(bytes, total, length - total);
                if (read == 0)
                    return null;
                total += read;
            }
            return bytes;
        }
        private void SendBytes(Stream s, byte[] bytes)
        {
            int total = 0;
            while (total < bytes.length)
            {
                total += s.Write(bytes, total, bytes.length - total);
            }
        }
        private bool ReadUInt32(Stream s, out uint value)
        {
            byte[] bytes = ReadBytes(s, 4);
            if (bytes == null)
                return false;
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes); 
            value = BitConverter.ToUInt32(bytes, 0);
            return true;
        }
        private void SendUInt32(Stream s, uint value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes); 
            SendBytes(s, bytes);
        }
        private bool ReadString(Stream s, out string value)
        {
            value = "";
            uint length;
            if (!ReadUInt32(s, length))
                return false;
            if (length > 0)
            {
                byte[] bytes = ReadBytes(s, length);
                if (bytes == null)
                    return false;
                value = System.Text.Encoding.UTF8.GetString(bytes);
            }
            return true;
        }
        private void SendString(Stream s, string value)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value);
            SendUInt32(s, bytes.length);
            SendBytes(s, bytes);
        }
        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;
            Stream s = client.GetStream();
    
            string data;
            while (ReadString(s, data))
            {
                Console.WriteLine("Received: {0}", data);
    
                // Process the data sent by the client.
                data = data.ToUpper();
    
                // Send back a response.
                SendString(s, data);
                Console.WriteLine("Sent: {0}", data);
            }    
        } 
    }
    
    namespace Multi_Threaded_TCP
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Multi-Threaded TCP Server Demo");
                TcpServer server = new TcpServer(1111);
            }
        }
    }
    
