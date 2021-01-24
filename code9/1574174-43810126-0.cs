    using System;
    using System.Threading;
    using System.Net.Sockets;
    using System.Text;
    using System.Collections;
    
    namespace ChatServer
    {
        class Program
        {
            public static Hashtable clientsList = new Hashtable();
    
            static void Main(string[] args)
            {
                TcpListener serverSocket = new TcpListener(8888);
                TcpClient clientSocket = default(TcpClient);
                int counter = 0;
    
                serverSocket.Start();
                Console.WriteLine("Chat Server Started ....");
                counter = 0;
                while ((true))
                {
                    counter += 1;
                    clientSocket = serverSocket.AcceptTcpClient();
    
                    byte[] bytesFrom = new byte[1000025];
                    string dataFromClient = null;
    
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
    
                    clientsList.Add(dataFromClient, clientSocket);
    
                    broadcast(dataFromClient + " Joined ", dataFromClient, false);
    
                    Console.WriteLine(dataFromClient + " Joined chat room ");
                    handleClinet client = new handleClinet();
                    client.startClient(clientSocket, dataFromClient, clientsList);
                }
    
                clientSocket.Close();
                serverSocket.Stop();
                Console.WriteLine("exit");
                Console.ReadLine();
            }
    
            public static void broadcast(string msg, string uName, bool flag)
            {
                foreach (DictionaryEntry Item in clientsList)
                {
                    TcpClient broadcastSocket;
                    broadcastSocket = (TcpClient)Item.Value;
                    NetworkStream broadcastStream = broadcastSocket.GetStream();
                    Byte[] broadcastBytes = null;
    
                    if (flag == true)
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
                    }
                    else
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(msg);
                    }
    
                    broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                    broadcastStream.Flush();
                }
            } 
        }
    
    
        public class handleClinet
        {
            TcpClient clientSocket;
            string clNo;
            Hashtable clientsList;
    
            public void startClient(TcpClient inClientSocket, string clineNo, Hashtable cList)
            {
                this.clientSocket = inClientSocket;
                this.clNo = clineNo;
                this.clientsList = cList;
                Thread ctThread = new Thread(doChat);
                ctThread.Start();
            }
    
            private void doChat()
            {
                int requestCount = 0;
                byte[] bytesFrom = new byte[100025];
                string dataFromClient = null;
                Byte[] sendBytes = null;
                string serverResponse = null;
                string rCount = null;
                requestCount = 0;
    
                while ((true))
                {
                    try
                    {
                        requestCount = requestCount + 1;
                        NetworkStream networkStream = clientSocket.GetStream();
                        networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                        dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                        dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                        Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                        rCount = Convert.ToString(requestCount);
    
                        Program.broadcast(dataFromClient, clNo, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }//end while
            }//end doChat
        } //end class handleClinet
    }
