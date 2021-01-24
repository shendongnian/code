    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Server
    {
        public class Program
        {
            static List<SocketBuffer> clients = new List<SocketBuffer>();
            public static void Main(string[] args)
            {
                //Receive from any IP, listen on port 65000 in this machine
                var listener = new TcpListener(IPAddress.Any, 65000);
                var t = Task.Run(() =>
                {
                    while (true)
                    {
                        listener.Start();
                        var task = listener.AcceptTcpClientAsync();
                        task.Wait();
                        clients.Add(new SocketBuffer(task.Result, new byte[4096]));
                    }
                });
                t.Wait();    //It will remain here, do in a better way if you like !
            }
        }
    
        /// <summary>
        /// We need this class because each TcpClient will have its own buffer
        /// </summary>
        class SocketBuffer
        {
            public SocketBuffer(TcpClient client, byte[] buffer)
            {
                this.client = client;
                stream = client.GetStream();
                this.buffer = buffer;
    
                receiveData(null);
            }
    
            private TcpClient client;
            private NetworkStream stream;
            private byte[] buffer;
    
            private object _lock = new object();
            private async void receiveData(Task<int> result)
            {
                if (result != null)
                {
                    lock (_lock)
                    {
                        int numberOfBytesRead = result.Result;
                        //If no data read, it means we are here to be notified that the tcp client has been disconnected
                        if (numberOfBytesRead == 0)
                        {
                            onDisconnected();
                            return;
                        }
                        //We need a part of this array, you can do it in more efficient way if you like
                        var segmentedArr = new ArraySegment<byte>(buffer, 0, numberOfBytesRead).ToArray();
                        OnDataReceived(segmentedArr);
                    }
                    
                }
                var task = stream.ReadAsync(buffer, 0, buffer.Length);
                //This is not recursion in any sense because the current 
                //thread will be free and the call to receiveData will be from a new thread
                await task.ContinueWith(receiveData);       
            }
    
            private void onDisconnected()
            {
                //Add your code here if you want this event
            }
    
            private void OnDataReceived(byte[] dat)
            {
                //Do anything with the data, you can reply here. I will just pring the received data from the demo client
                string receivedTxt = Encoding.ASCII.GetString(dat);
                Console.WriteLine(receivedTxt);
            }
        }
    }
